using System;
using Interfaces;
using Managers;
using UnityEngine;
using UnityEngine.Events;

namespace Components
{
    /// <summary>
    /// 角色输入组件：收集玩家输入并分发给动作与移动逻辑
    /// </summary>
    public class CharacterInputComponent : MonoBehaviour
    {
        [Header("按键映射")] [SerializeField] private KeyCode leftKey = KeyCode.A;
        [SerializeField] private KeyCode rightKey = KeyCode.D;
        [SerializeField] private KeyCode jumpKey = KeyCode.Space;
        [SerializeField] private KeyCode attackKey = KeyCode.J;

        [Header("互动按键")] [SerializeField] private KeyCode greetingKey = KeyCode.Alpha1;
        [SerializeField] private KeyCode chatKey = KeyCode.Alpha2;
        [SerializeField] private KeyCode roarKey = KeyCode.Alpha3;

        public UnityAction OnGreeting;
        public UnityAction OnChat;
        public UnityAction OnRoar;
        public UnityAction<Vector2> OnMove;
        public UnityAction OnJump;
        public UnityAction OnAttack;
        private Animator _animator;

        IActions _iActions;
        IAttribute _iAttribute;
        CharacterMoveComponent characterMoveComponent;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _iActions = GetComponent<IActions>();
            characterMoveComponent = GetComponent<CharacterMoveComponent>();
            _iAttribute = GetComponent<IAttribute>(); // 获取属性接口

            // 动作绑定
            if (_iActions != null)
            {
                OnGreeting += _iActions.Greeting;
                OnChat += _iActions.Chat;
                OnRoar += _iActions.Roar;
                OnAttack += _iActions.Attack; // 假设 IActions 里有 Attack 方法
            }

            if (characterMoveComponent != null)
            {
                OnMove += characterMoveComponent.OnMove;
                OnJump += characterMoveComponent.OnJump;
            }
        }

        private void Update()
        {
            if (_iAttribute != null && _iAttribute.GetRunTimeAttributeValue(ERunTimeAttributeType.IsAlive))
            {
                HandleMovement();
                HandleInteraction();
                HandleAttack();
            }
        }

        /// <summary>
        /// 角色移动输入
        /// </summary>
        void HandleMovement()
        {
            // if (!_iAttribute.GetRunTimeAttributeValue(ERunTimeAttributeType.CanMove)) return;

            // 左右移动
            if (Input.GetKey(leftKey))
                OnMove?.Invoke(Vector2.left);

            if (Input.GetKey(rightKey))
                OnMove?.Invoke(Vector2.right);

            if (Input.GetKeyUp(leftKey) || Input.GetKeyUp(rightKey))
                OnMove?.Invoke(Vector2.zero);

            // 跳跃（用 KeyDown 避免长按无限触发）
            if (Input.GetKeyDown(jumpKey))
                OnJump?.Invoke();
        }

        /// <summary>
        /// 角色交互输入
        /// </summary>
        void HandleInteraction()
        {
            Debug.Log(_iAttribute.GetRunTimeAttributeValue(ERunTimeAttributeType.InInteractiveArea));
            //交互区域判定
            if (!_iAttribute.GetRunTimeAttributeValue(ERunTimeAttributeType.InInteractiveArea)) return;
            // //地面判定
            // if (!_iAttribute.GetRunTimeAttributeValue(ERunTimeAttributeType.IsGround)) return;
            //行动判定
            if (_animator.GetBool("isMoving")) return;

            if (Input.GetKeyDown(greetingKey))
                OnGreeting?.Invoke();

            if (Input.GetKeyDown(chatKey))
                OnChat?.Invoke();

            if (Input.GetKeyDown(roarKey))
                OnRoar?.Invoke();
        }

        /// <summary>
        /// 攻击输入
        /// </summary>
        void HandleAttack()
        {
            if (Input.GetKeyDown(attackKey))
                OnAttack?.Invoke();
        }

        private void OnDestroy()
        {
            // 防止事件未解绑导致内存泄漏
            if (_iActions != null)
            {
                OnGreeting -= _iActions.Greeting;
                OnChat -= _iActions.Chat;
                OnRoar -= _iActions.Roar;
                OnAttack -= _iActions.Attack;
            }

            if (characterMoveComponent != null)
            {
                OnMove -= characterMoveComponent.OnMove;
                OnJump -= characterMoveComponent.OnJump;
            }
        }
    }
}