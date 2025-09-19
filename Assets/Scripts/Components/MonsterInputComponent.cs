using Interfaces;
using UnityEngine;
using UnityEngine.Events;

namespace Components
{
    public class MonsterInputComponent : MonoBehaviour
    {
        public UnityAction OnBow;
        public UnityAction OnRoar;
        public UnityAction OnSpitting;

        IActions _iActions;

        private void Start()
        {
            _iActions = GetComponent<IActions>();

            OnBow += _iActions.Greeting;
            OnRoar += _iActions.Chat;
            OnSpitting += _iActions.Roar;
        }


        private void Update()
        {
        }
    }
}