using Interfaces;
using UnityEngine;

namespace Components
{
    public class CharacterActionsComponent : MonoBehaviour, IActions
    {
        Animator animator;
        IAttribute _IAttribute;


        private void Awake()
        {
            animator = GetComponent<Animator>();
            _IAttribute = GetComponent<AttributesComponent>();
        }

        public void Greeting()
        {
            animator.SetTrigger(AnimatorString.Greeting);
        }

        public void Chat()
        {

            animator.SetTrigger(AnimatorString.Chat);
        }

        public void Roar()
        {
            animator.SetTrigger(AnimatorString.Roar);
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