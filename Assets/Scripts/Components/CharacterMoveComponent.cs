using Assets.Scripts.DataConfig;
using Managers;
using UnityEngine;

namespace Components
{
    /// <summary>
    /// 角色移动脚本
    /// </summary>
    public class CharacterMoveComponent : MonoBehaviour
    {
        public float moveSpeed = 5f; // 移动速度
        public float jumpForce = 5f; // 跳跃速度

        Rigidbody2D rb;
        Animator animator;
        StateControlComponent stateController;

        Vector2 moveInput = Vector2.zero;

        //private void OnEnable()
        //{
        //    EventManager.Instance.RegisterEventListener<JumpEvent>(OnJump);
        //}

        //private void OnDisable()
        //{
        //    EventManager.Instance?.UnregisterEventListener<JumpEvent>(OnJump);
        //}


        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
            stateController = GetComponent<StateControlComponent>();
        }

        public void OnMove(Vector2 move)
        {
            //TODO：判断是否存活，判断是否正在交互
            moveInput = move;
        }

        public void OnJump()
        {
            //TODO：在动画机设置跳跃结束IsJumping为false
            if (stateController.IsJumping) return;

            stateController.IsJumping = true;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        void Update()
        {
            rb.velocity = new Vector2(moveInput.x * moveSpeed, rb.velocity.y);
        }
    }
}