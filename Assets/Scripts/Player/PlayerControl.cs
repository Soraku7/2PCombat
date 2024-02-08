using System.Collections.Generic;
using ScriptsObject;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerControl : MonoBehaviour
    {
        [Header("数值")]
        public float health;
        private float _movementSpeed = 10;
        
        private Vector2 _movement;
        private Rigidbody2D _rbody;
        
        [Header("组件")]
        public Head head;
        public Torso torso;
        public Foot foot;
        
        private void Awake()
        {
            _rbody = GetComponent<Rigidbody2D>();
        }

        void Start()
        {
            
        }
    
        void Update()
        {
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

            Vector2 adjustedMovement = _movement * _movementSpeed;

            Vector2 newPos = currentPos + adjustedMovement * Time.fixedDeltaTime;

            _rbody.MovePosition(newPos);
        }

        #region InputSystem

        private void OnMove(InputValue value)
        {
            _movement = value.Get<Vector2>();
        }
        private void OnHead(InputValue value)
        {
            head.Skill();
        }
        private void OnTorso(InputValue value)
        {
            torso.Skill();
        }

        private void OnFoot(InputValue value)
        {
            foot.Skill();
        }
        
        #endregion

    }
}
