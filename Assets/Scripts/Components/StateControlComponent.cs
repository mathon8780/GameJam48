using UnityEngine;

namespace Components
{
    /// <summary>
    /// 状态控制
    /// </summary>
    public class StateControlComponent : MonoBehaviour
    {
        Animator animator;

        [Tooltip("是否在移动")]
        [SerializeField]
        private bool _isMoving = false;
        public bool IsMoving
        {
            get
            {
                _isMoving = animator.GetBool(AnimatorString.isMoving);
                return _isMoving;
            }
            set
            {
                _isMoving = value;
                animator.SetBool(AnimatorString.isMoving, _isMoving);
            }
        }

        [Tooltip("是否在跳跃")]
        [SerializeField]
        private bool _isJumping = false;
        public bool IsJumping
        {
            get
            {
                _isJumping = animator.GetBool(AnimatorString.isJumping);
                return _isJumping;
            }
            set
            {
                _isJumping = value;
                animator.SetBool(AnimatorString.isJumping, _isJumping);
                if(_isJumping) animator.SetTrigger(AnimatorString.Jump);
            }
        }

        [Tooltip("是否存活")]
        [SerializeField]
        private bool _isAlive = true;
        public bool IsAlive
        {
            get { return _isAlive; }
            set
            {
                _isAlive = value;
                animator.SetBool(AnimatorString.isAlive, _isAlive);
            }
        }

        [Tooltip("是否在交互")]
        [SerializeField]
        private bool _isInteracting = false;
        public bool IsInteractive
        {
            get { return _isInteracting; }
            set
            {
                _isInteracting = value;
                animator.SetBool(AnimatorString.isInteractive, _isInteracting);
            }
        }
        

        
        void Awake()
        {
            animator = GetComponent<Animator>();
        }
    }
}