using Assets.Scripts.DataConfig;
using Interfaces;
using Managers;
using UnityEngine;
using UnityEngine.Events;

namespace Components
{
    /// <summary>
    /// 角色移动脚本
    /// </summary>
    public class CharacterMoveComponent : MonoBehaviour
    {
        public float moveSpeed = 5f; // 移动速度
        public float jumpForce = 5f; // 跳跃速度
        public float falling = 8f; // 下落速度

        Rigidbody2D rb;
        CapsuleCollider2D capsuleCollider2D;
        StateControlComponent stateController;
        IAttribute _IAttributes;

        Vector2 moveInput = Vector2.zero;

        public ContactFilter2D contactFilter;
        RaycastHit2D[] groundResults = new RaycastHit2D[5];


        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            stateController = GetComponent<StateControlComponent>();
            _IAttributes = GetComponent<AttributesComponent>();
            capsuleCollider2D = GetComponent<CapsuleCollider2D>();

        }

        public void OnMove(Vector2 move)
        {
            //TODO：判断是否存活，判断是否正在交互
            moveInput = move;
        }

        public void OnJump()
        {
            if (stateController.IsGround)
            {
                stateController.Jump();
                rb.velocity = new Vector2(rb.velocity.x, _IAttributes.GetAttributesValue(EAttributeType.JumpHeight));
            }
        }

        void Update()
        {
            rb.velocity = new Vector2(moveInput.x * _IAttributes.GetAttributesValue(EAttributeType.MoveSpeed), rb.velocity.y);
            if(!stateController.IsGround)
            {
                rb.velocity -= new Vector2(0, falling * Time.deltaTime * 1.1f);
            }
        }

        private void FixedUpdate()
        {
            stateController.IsGround = capsuleCollider2D.Cast(Vector2.down, contactFilter, groundResults, 0.05f) > 0;
        }
    }
}