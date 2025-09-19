using System;
using Assets.Scripts.DataConfig;
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

        IActions _iAtk;

        StateControlComponent stateController;
        CharacterMoveComponent characterMoveComponent;

        private void Awake()
        {
            _iAtk = GetComponent<IActions>();
            characterMoveComponent = GetComponent<CharacterMoveComponent>();
            stateController = GetComponent<StateControlComponent>();

            OnGreeting += _iAtk.Greeting;
            OnChat += _iAtk.Chat;
            OnRoar += _iAtk.Roar;

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

            //JUMP
            if (Input.GetKey(KeyCode.Space))
            {
                //Debug.Log("Jump");
                //EventManager.Instance.TriggerEvent<JumpEvent>();
                OnJump?.Invoke();
            }
        }

        void Interactive()
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