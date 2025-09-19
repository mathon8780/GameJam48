using UnityEngine;

namespace Components
{
    /// <summary>
    /// 状态控制
    /// </summary>
    public class StateControlComponent : MonoBehaviour
    {
        public Animator animator;

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
        
        public void OnJump()
        {
            animator.SetTrigger(AnimatorString.isJumping);
        }
        void Awake()
        {
            animator = GetComponent<Animator>();
        }
    }
}