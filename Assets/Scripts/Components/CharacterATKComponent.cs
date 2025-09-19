using Interfaces;
using UnityEngine;

namespace Components
{
    public class CharacterATKComponent : MonoBehaviour, IAtk
    {
        Animator animator;

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }
        public void Bow()
        {
            animator.SetTrigger(AnimatorString.Bow);
        }

        public void Roar()
        {
            animator.SetTrigger(AnimatorString.Roar);
        }

        public void Spitting()
        {
            animator.SetTrigger(AnimatorString.Spitting);
        }

        public void Attack()
        {
            animator.SetTrigger(AnimatorString.Attack);
        }
    }
}