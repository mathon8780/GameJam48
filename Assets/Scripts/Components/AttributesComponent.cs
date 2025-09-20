using System;
using DataConfig;
using Interfaces;
using UnityEngine;

namespace Components
{
    public class AttributesComponent : MonoBehaviour, IAttribute
    {
        Animator animator;
        //关联的原始信息
        [SerializeField] private PlayerAttributes attributes;

        //运行时的副本信息
        private PlayerAttributes _runTimeAttributes;


        private void Awake()
        {
            //创建运行时副本
            if (!attributes)
                Debug.LogError("AttributesComponent: attributes is null");

            _runTimeAttributes = Instantiate(attributes);

            animator = GetComponent<Animator>();
        }

        /// <summary>
        /// 用于获取属性值
        /// </summary>
        /// <param name="attributeType"></param>
        /// <returns></returns>
        public float GetAttributesValue(EAttributeType attributeType)
        {
            switch (attributeType)
            {
                case EAttributeType.HP:
                    return _runTimeAttributes.Hp + _runTimeAttributes.FixedHp;
                case EAttributeType.MaxHP:
                    return _runTimeAttributes.MaxHp;
                case EAttributeType.FixedHP:
                    return _runTimeAttributes.FixedHp;
                case EAttributeType.MoveSpeed:
                    return _runTimeAttributes.MoveSpeed;
                case EAttributeType.JumpHeight:
                    return _runTimeAttributes.JumpHeight;
                case EAttributeType.Calmness:
                    return _runTimeAttributes.Calmness;
                case EAttributeType.Defense:
                    return _runTimeAttributes.Defense;
            }

            return 0;
        }

        /// <summary>
        /// 用于修改fixed属性值与最大值
        /// </summary>
        /// <param name="attributeType">属性</param>
        /// <param name="varValue">修改值</param>
        public void SetAttributesValue(EAttributeType attributeType, float varValue)
        {
            switch (attributeType)
            {
                case EAttributeType.MaxHP:
                    _runTimeAttributes.MaxHp += (int)varValue;
                    break;
                case EAttributeType.FixedHP:
                    _runTimeAttributes.FixedHp += (int)varValue;
                    break;
                case EAttributeType.MoveSpeed:
                    _runTimeAttributes.MoveSpeed += varValue;
                    break;
                case EAttributeType.Calmness:
                    _runTimeAttributes.Calmness += varValue;
                    break;
                case EAttributeType.Defense:
                    _runTimeAttributes.Defense += varValue;
                    break;
            }
        }

        /// <summary>
        /// 获取玩家状态
        /// </summary>
        /// <returns></returns>
        public EPlayerState GetPlayerState()
        {
            return _runTimeAttributes.playerState;
        }

        /// <summary>
        /// 设置玩家状态
        /// </summary>
        /// <param name="state">目标状态</param>
        public void SetPlayerState(EPlayerState state)
        {
            _runTimeAttributes.playerState = state;
        }

        public bool GetRunTimeAttributeValue(ERunTimeAttributeType runTimeAttributeType)
        {
            switch (runTimeAttributeType)
            {
                case ERunTimeAttributeType.InInteractiveArea:
                    return _runTimeAttributes.CanInteractive;
                case ERunTimeAttributeType.IsGround:
                    return _runTimeAttributes.IsGround;
                case ERunTimeAttributeType.canMove:
                    return animator.GetBool(AnimatorString.canMove);
                case ERunTimeAttributeType.IsMoving:
                    return _runTimeAttributes.IsMoving;
                case ERunTimeAttributeType.isAlive:
                    return _runTimeAttributes.isAlive;
            }

            return false;
        }

        public void SetRunTimeAttributeValue(ERunTimeAttributeType runTimeAttributeType, bool value)
        {
            switch (runTimeAttributeType)
            {
                case ERunTimeAttributeType.InInteractiveArea:
                    _runTimeAttributes.CanInteractive = value;
                    break;
                case ERunTimeAttributeType.IsGround:
                    _runTimeAttributes.IsGround = value;
                    break;
                case ERunTimeAttributeType.canMove:
                    _runTimeAttributes.canMove = value;
                    break;
                case ERunTimeAttributeType.IsMoving:
                    _runTimeAttributes.IsMoving = value;
                    animator.SetBool(AnimatorString.isMoving, value);
                    break;
                case ERunTimeAttributeType.isAlive:
                    _runTimeAttributes.isAlive = value;
                    break;
            }
        }
    }
}