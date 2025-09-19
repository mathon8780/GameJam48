using Interfaces;
using UnityEngine;

namespace Components
{
    public class CharacterActionsComponent : MonoBehaviour, IActions
    {
        Animator animator;

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        public void Greeting()
        {
        }

        public void Chat()
        {
        }

        public void Roar()
        {
        }

        public void Attack()
        {
        }
    }
}