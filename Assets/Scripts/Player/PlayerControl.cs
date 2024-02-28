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


        private BoxCollider2D _col;
        public Rigidbody2D _rbody;

        private Vector2 _movement;
        public LayerMask groundLayer;
        public bool isOnGround;

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
        }

        void Update()
        {
            CheckIsGround();
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

        #region InputSystem

        private void OnMove(InputValue value)
        {
            _movement = value.Get<Vector2>();
        }

        private void OnHead(InputValue value)
        {
            Debug.Log("头部技能");
        }

        private void OnTorso(InputValue value)
        {
            Debug.Log("躯干技能");
        }

        private void OnFoot(InputValue value)
        {
            if (isOnGround)
            {
                Debug.Log("跳跃");
                _rbody.AddForce(Vector3.up * jumpForce);
                isOnGround = false;
            }
            
            jumpCount--;
            
            if (!isOnGround)
            {
                //在空中时 技能释放
                Debug.Log("腿部技能");
                DoubleSkill();
            }
        }

        #endregion

        IEnumerator UseFootSkill()
        {
            Debug.Log("触发技能");
            while (true)
            {
                switch (foot.footSkill)
                {
                    case FootSkill.DoubleJump:
                        DoubleSkill();
                        Debug.Log("二段跳");
                        yield return new WaitForSeconds(foot.coldTime);
                        break;
                    
                    default:
                        yield return 0;
                        break;
                }
            }
        }


        #region PlayerSkill

        private void DoubleSkill()
        {
            if (jumpCount > 0)
            {
                _rbody.AddForce(Vector3.up * jumpForce);
            }
        }

        #endregion
    }
}
