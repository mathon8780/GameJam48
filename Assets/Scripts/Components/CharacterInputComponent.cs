using System;
using Interfaces;
using Managers;
using UnityEngine;
using UnityEngine.Events;

namespace Components
{
    public class CharacterInputComponent : MonoBehaviour
    {
        public UnityAction OnGreeting;
        public UnityAction OnChat;
        public UnityAction OnRoar;
        public UnityAction<Vector2> OnMove;
        public UnityAction OnJump;

        IActions _iActions;

        StateControlComponent stateController;
        CharacterMoveComponent characterMoveComponent;

        private void Awake()
        {
            _iActions = GetComponent<CharacterActionsComponent>();
            characterMoveComponent = GetComponent<CharacterMoveComponent>();
            stateController = GetComponent<StateControlComponent>();

            OnGreeting += _iActions.Greeting;
            OnChat += _iActions.Chat;
            OnRoar += _iActions.Roar;

            OnMove += characterMoveComponent.OnMove;
            OnJump += characterMoveComponent.OnJump;
        }

        private void Update()
        {
            Move();
            Interact();
        }

        void Move()
        {
            //左右移动
            if (Input.GetKey(KeyCode.A))
            {
                OnMove?.Invoke(Vector2.left);
            }

            if (Input.GetKey(KeyCode.D))
            {
                OnMove?.Invoke(Vector2.right);
            }

            if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
            {
                OnMove?.Invoke(Vector2.zero);
            }

            //跳跃
            if (Input.GetKeyDown(KeyCode.Space))
            {
                OnJump?.Invoke();
            }
        }

        void Interact()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                OnGreeting?.Invoke();
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                OnChat?.Invoke();
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                OnRoar?.Invoke();
            }
        }
    }
}