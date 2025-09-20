using System;
using DataConfig;
using Interfaces;
using UnityEngine;
using Random = UnityEngine.Random;


namespace Components
{
    public class MonsterAttributesComponent : MonoBehaviour, IMonsterAttribute
    {
        Animator animator;

        //关联属性
        [SerializeField] private MonsterAttribute attributes;

        //运行时属性
        private MonsterAttribute _runTimeAttributes;


        private void Awake()
        {
            //创建运行时副本
            if (!attributes)
                Debug.LogError("AttributesComponent: attributes is null");

            _runTimeAttributes = Instantiate(attributes);
            InitAttributes(_runTimeAttributes);

            animator = GetComponent<Animator>();
        }

        private void InitAttributes(MonsterAttribute runTimeAttributes)
        {
            //随机初始值
            runTimeAttributes.StartAnger += Random.Range(-runTimeAttributes.StartChangeRange, runTimeAttributes.StartChangeRange + 1);
        }


        /// <summary>
        /// 获得属性值
        /// </summary>
        /// <param name="attributeType">属性类型</param>
        /// <returns>属性值</returns>
        public float GetAttributesValue(EMonsterAttributeType attributeType)
        {
            switch (attributeType)
            {
                case EMonsterAttributeType.MoveSpeed:
                    return _runTimeAttributes.MoveSpeed;
                case EMonsterAttributeType.LeftDistance:
                    return _runTimeAttributes.LeftDistance;
                case EMonsterAttributeType.RightDistance:
                    return _runTimeAttributes.RightDistance;
                case EMonsterAttributeType.StartAnger:
                    return _runTimeAttributes.StartAnger;
                case EMonsterAttributeType.FixedAnger:
                    return _runTimeAttributes.FixedAnger;
                case EMonsterAttributeType.StartChangeRange:
                    return _runTimeAttributes.StartChangeRange;
                case EMonsterAttributeType.ThresholdA:
                    return _runTimeAttributes.ThresholdA;
                case EMonsterAttributeType.ThresholdAChangeRange:
                    return _runTimeAttributes.ThresholdAChangeRange;
                case EMonsterAttributeType.FixedThresholdA:
                    return _runTimeAttributes.FixedThresholdA;
                case EMonsterAttributeType.ThresholdB:
                    return _runTimeAttributes.ThresholdB;
                case EMonsterAttributeType.ThresholdBChangeRange:
                    return _runTimeAttributes.ThresholdBChangeRange;
                case EMonsterAttributeType.FixedThresholdB:
                    return _runTimeAttributes.FixedThresholdB;
                case EMonsterAttributeType.MaxMistakes:
                    return _runTimeAttributes.MaxMistakes;
                case EMonsterAttributeType.CurrentMistakes:
                    return _runTimeAttributes.CurrentMistakes;
                case EMonsterAttributeType.Atk:
                    return _runTimeAttributes.Atk;
                case EMonsterAttributeType.AngerIncreaseRate:
                    return _runTimeAttributes.AngerIncreaseRate;
                case EMonsterAttributeType.CalmnessThreshold:
                    return _runTimeAttributes.CalmnessThreshold;
                case EMonsterAttributeType.IsRampage:
                    return _runTimeAttributes.IsRampage ? 1 : 0;
                case EMonsterAttributeType.UpgradeValue:
                    return _runTimeAttributes.UpgradeValue;
            }

            return 0;
        }

        /// <summary>
        /// 设置属性值
        /// </summary>
        /// <param name="attributeType">属性类型</param>
        /// <param name="varValue">变化值</param>
        public void SetAttributesValue(EMonsterAttributeType attributeType, float varValue)
        {
            switch (attributeType)
            {
                case EMonsterAttributeType.MoveSpeed:
                    _runTimeAttributes.MoveSpeed += varValue;
                    break;
                case EMonsterAttributeType.StartAnger:
                    _runTimeAttributes.StartAnger += varValue;
                    break;
                case EMonsterAttributeType.FixedAnger:
                    _runTimeAttributes.FixedAnger += varValue;
                    break;
                case EMonsterAttributeType.StartChangeRange:
                    _runTimeAttributes.StartChangeRange += varValue;
                    break;
                case EMonsterAttributeType.ThresholdA:
                    _runTimeAttributes.ThresholdA += varValue;
                    break;
                case EMonsterAttributeType.ThresholdAChangeRange:
                    _runTimeAttributes.ThresholdAChangeRange += varValue;
                    break;
                case EMonsterAttributeType.FixedThresholdA:
                    _runTimeAttributes.FixedThresholdA += varValue;
                    break;
                case EMonsterAttributeType.ThresholdB:
                    _runTimeAttributes.ThresholdB += varValue;
                    break;
                case EMonsterAttributeType.ThresholdBChangeRange:
                    _runTimeAttributes.ThresholdBChangeRange += varValue;
                    break;
                case EMonsterAttributeType.FixedThresholdB:
                    _runTimeAttributes.FixedThresholdB += varValue;
                    break;
                case EMonsterAttributeType.MaxMistakes:
                    _runTimeAttributes.MaxMistakes += (int)varValue;
                    break;
                case EMonsterAttributeType.CurrentMistakes:
                    _runTimeAttributes.CurrentMistakes += (int)varValue;
                    break;
                case EMonsterAttributeType.Atk:
                    _runTimeAttributes.Atk += varValue;
                    break;
                case EMonsterAttributeType.AngerIncreaseRate:
                    _runTimeAttributes.AngerIncreaseRate += varValue;
                    break;
                case EMonsterAttributeType.CalmnessThreshold:
                    _runTimeAttributes.CalmnessThreshold += varValue;
                    break;
                case EMonsterAttributeType.IsRampage:
                    if (Mathf.Approximately(varValue, 1))
                    {
                        _runTimeAttributes.IsRampage = true;
                    }
                    else if (varValue == 0)
                    {
                        _runTimeAttributes.IsRampage = false;
                    }

                    break;
            }
        }

        /// <summary>
        /// 获得怪物状态
        /// </summary>
        /// <returns></returns>
        public EMonsterState GetMonsterState()
        {
            return _runTimeAttributes.MonsterState;
        }

        /// <summary>
        /// 设置怪物状态
        /// </summary>
        /// <param name="state"></param>
        public void SetMonsterState(EMonsterState state)
        {
            _runTimeAttributes.MonsterState = state;
            switch(state)
            {
                case EMonsterState.Patrol:
                    animator.SetBool(AnimatorString.isMoving, true);
                    break;
            }
        }

        public EUpgradeAttribute GetUpgradeAttribute()
        {
            return _runTimeAttributes.UpgradeAttribute;
        }
    }
}