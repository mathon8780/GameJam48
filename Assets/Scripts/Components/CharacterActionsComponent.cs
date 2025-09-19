using Interfaces;
using UnityEngine;

namespace Components
{
    public class CharacterActionsComponent : MonoBehaviour, IActions
    {
        Animator animator;
        IAttribute attribute;

        private void Awake()
        {
            animator = GetComponent<Animator>();
            attribute = GetComponent<AttributesComponent>();
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
    }
}