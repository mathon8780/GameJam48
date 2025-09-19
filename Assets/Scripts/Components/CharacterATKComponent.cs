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

        }

        public void Roar()
        {
        }

        public void Spitting()
        {
        }
    }
}