using System;
using Interfaces;
using UnityEngine;
using UnityEngine.Events;

namespace Components
{
    public class InputComponent : MonoBehaviour
    {
        public UnityAction OnBow;
        public UnityAction OnRoar;
        public UnityAction OnSpitting;

        IAtk _iAtk;

        private void Start()
        {
            _iAtk = GetComponent<IAtk>();
            if (_iAtk == null)
            {
                Debug.LogError("IAtk interface not found on the GameObject.");
            }

            OnBow += _iAtk.Bow;
            OnRoar += _iAtk.Roar;
            OnSpitting += _iAtk.Spitting;
        }


        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                OnBow?.Invoke();
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                OnRoar?.Invoke();
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                OnSpitting?.Invoke();
            }
        }
    }
}