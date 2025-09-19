using System;
using Interfaces;
using UnityEngine;
using UnityEngine.Events;

namespace Components
{
    public class CharacterInputComponent : MonoBehaviour
    {
        public UnityAction OnBow;
        public UnityAction OnRoar;
        public UnityAction OnSpitting;
        public UnityAction<Vector2> OnMove;
        public UnityAction OnJump;

        IAtk _iAtk;

        StateControlComponent stateController;
        CharacterMoveComponent characterMoveComponent;

        private void Awake()
        {
            _iAtk = GetComponent<IAtk>();
            characterMoveComponent = GetComponent<CharacterMoveComponent>();
            stateController = GetComponent<StateControlComponent>();

            OnBow += _iAtk.Bow;
            OnRoar += _iAtk.Roar;
            OnSpitting += _iAtk.Spitting;

            OnMove += characterMoveComponent.OnMove;
            OnJump += characterMoveComponent.OnJump;
        }

        private void Update()
        {
            Move();
            Interactive();
        }

        void Move()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                OnMove?.Invoke(Vector2.left);
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                OnMove?.Invoke(Vector2.right);
            }

            if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
            {
                OnMove?.Invoke(Vector2.zero);
            }

            //JUMP
            if (Input.GetKeyDown(KeyCode.Space))
            {
                OnJump?.Invoke();
            }
        }

        void Interactive()
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