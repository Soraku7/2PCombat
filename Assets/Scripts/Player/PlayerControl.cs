using System.Collections;
using System.Collections.Generic;
using Part;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

namespace Player
{
    public class PlayerControl : MonoBehaviour
    {
        [Header("数值")] public float health;
        public float movementSpeed = 10;
        public float jumpForce = 5000;
        public int jumpCount = 2;
        public bool isAirJet;
        public float jetSpeed = 10;


        private BoxCollider2D _col;
        public Rigidbody2D _rbody;

        private Vector2 _movement;
        public LayerMask groundLayer;
        public bool isOnGround;
        
        private float _footTimer;

        [Header("组件")] public Head head;
        public Torso torso;
        public Foot foot;

        private void Awake()
        {
            _rbody = GetComponent<Rigidbody2D>();
            _col = GetComponent<BoxCollider2D>();
        }

        void Start()
        {
            _footTimer = foot.coldTime;
        }

        void Update()
        {
            CheckIsGround();
            UpdateTimer();
            OnFootSkill();
            Move();
        }

        void FixedUpdate()
        {
            Movement();
        }

        /// <summary>
        /// 移动
        /// </summary>
        private void Movement()
        {
            Vector2 currentPos = _rbody.position;

            Vector2 adjustedMovement = _movement * movementSpeed;

            Vector2 newPos = currentPos + adjustedMovement * Time.fixedDeltaTime;

            _rbody.MovePosition(newPos);
        }

        private void CheckIsGround()
        {
            if (_col.IsTouchingLayers(groundLayer))
            {
                isOnGround = true;
                jumpCount = 2;
            }
            else
            {
                isOnGround = false;
            }
        }

        private void UpdateTimer()
        {
            _footTimer -= Time.deltaTime;
        }
        
        #region InputSystem

        private void Move()
        {
            _movement = GameInputManager.MainInstance.Move;
            
            int faceDir = (int)_movement.x > 0? 1 : -1;
            transform.localScale = new Vector3(faceDir, 1, 1);
        }

        private void OnHead(InputValue value)
        {
            Debug.Log("头部技能");
        }

        private void OnTorso(InputValue value)
        {
            Debug.Log("躯干技能");
        }

        private void OnFootSkill()
        {
            if (GameInputManager.MainInstance.Foot)
            {
                if (isOnGround)
                {
                    Debug.Log("跳跃");
                    _rbody.AddForce(Vector3.up * jumpForce);
                    isOnGround = false;
                }
                else
                {
                    //在空中时 技能释放
                    Debug.Log("腿部技能");
                    UseFootSkill();
                }
                jumpCount--;
            }
        }

        #endregion

        private void  UseFootSkill()
        {
            switch (foot.footSkill)
            {
                case FootSkill.DoubleJump:
                    DoubleJumpSkill();
                    Debug.Log("二段跳");
                    break;
                case FootSkill.AirJet:
                    Debug.Log("空中喷射");
                    AirJetSkill();
                    break;
                default:
                    break;
                }
        }


        #region PlayerSkill

        private void DoubleJumpSkill()
        {
            if (jumpCount > 0)
            {
                _rbody.AddForce(Vector2.up * jumpForce);
            }
        }

        private void AirJetSkill()
        {
            transform.Translate(transform.localScale.x * (Time.deltaTime * jetSpeed) , 1 , 1);
        }
        #endregion
    }
}
