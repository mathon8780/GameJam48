using UnityEngine;
using Interfaces;

namespace Components
{
    /// <summary>
    /// 状态控制
    /// </summary>
    public class StateControlComponent : MonoBehaviour
    {
        Animator animator;
        IAttribute attribute;

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

        [Tooltip("是否在地面上")]
        [SerializeField]
        private bool _isGround = true;
        public bool IsGround
        {
            get
            {
                _isGround = animator.GetBool(AnimatorString.isGround);
                return _isGround;
            }
            set
            {
                _isGround = value;
                animator.SetBool(AnimatorString.isGround, _isGround);
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

        public void Jump()
        {
            animator.SetTrigger(AnimatorString.Jump);
        }

    }
}