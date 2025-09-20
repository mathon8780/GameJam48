using DataConfig;
using Detection;
using Interfaces;
using UnityEngine;

namespace Components
{
    public class CharacterActionsComponent : MonoBehaviour, IActions
    {
        Animator animator;
        IAttribute _IAttribute;
        public IDetectionInteraction _boxAreaDetection;


        private void Awake()
        {
            animator = GetComponent<Animator>();
            _IAttribute = GetComponent<AttributesComponent>();
            _boxAreaDetection = GetComponentInChildren<IDetectionInteraction>();
        }

        /// <summary>
        /// 问候
        /// </summary>
        public void Greeting()
        {
            animator.SetTrigger(AnimatorString.Greeting);
            _boxAreaDetection.TakeInteraction(EInteractiveType.Greeting);
        }

        /// <summary>
        /// 交谈
        /// </summary>
        public void Chat()
        {
            animator.SetTrigger(AnimatorString.Chat);
            _boxAreaDetection.TakeInteraction(EInteractiveType.Chat);
        }

        /// <summary>
        /// 吼
        /// </summary>
        public void Roar()
        {
            animator.SetTrigger(AnimatorString.Roar);
            _boxAreaDetection.TakeInteraction(EInteractiveType.Roar);
        }

        public void Attack()
        {
            animator.SetTrigger(AnimatorString.Attack);
        }

        public void BeAttacked()
        {
            animator.SetTrigger(AnimatorString.BeAttacked);
        }
    }
}