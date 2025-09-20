using System;
using DataConfig;
using Interfaces;
using Managers;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Components
{
    public class MonsterActionsComponent : MonoBehaviour, IReaction
    {
        private IMonsterAttribute _monsterAttribute;
        private Animator _animator;


        private void Start()
        {
            _monsterAttribute = GetComponent<IMonsterAttribute>();
            if (_monsterAttribute == null)
                Debug.LogError("MonsterActionsComponent: IMonsterAttribute component not found on the GameObject.");
            _animator = GetComponent<Animator>();
            if (!_animator)
                Debug.LogError("MonsterActionsComponent: Animator component not found on the GameObject.");
        }

        /// <summary>
        /// 产生交互接口 根据玩家的交互类型产生反应
        /// </summary>
        /// <param name="interactiveType">使用的交互对象</param>
        public void Interactive(EInteractiveType interactiveType)
        {
            //Debug.Log("Interactive OK");
            EInteractiveType targetType = EInteractiveType.None;
            float startAnger = _monsterAttribute.GetAttributesValue(EMonsterAttributeType.StartAnger);
            float fixedAnger = _monsterAttribute.GetAttributesValue(EMonsterAttributeType.FixedAnger);

            float thresholdA = _monsterAttribute.GetAttributesValue(EMonsterAttributeType.ThresholdA);
            float fixedThresholdA = _monsterAttribute.GetAttributesValue(EMonsterAttributeType.FixedThresholdA);

            float thresholdB = _monsterAttribute.GetAttributesValue(EMonsterAttributeType.ThresholdB);
            float fixedThresholdB = _monsterAttribute.GetAttributesValue(EMonsterAttributeType.FixedThresholdB);

            //第一个区间
            if (startAnger + fixedAnger <= thresholdA + fixedThresholdA)
            {
                targetType = EInteractiveType.Greeting;
            }
            //第二个区间
            else if (startAnger + fixedAnger > thresholdA + fixedThresholdA && startAnger + fixedAnger <= thresholdB + fixedThresholdB)
            {
                targetType = EInteractiveType.Chat;
            }
            //第三个区间
            else if (startAnger + fixedAnger > thresholdB + fixedThresholdB)
            {
                targetType = EInteractiveType.Roar;
            }

            //交互成功判定
            if (interactiveType != targetType)
                Wrong();
            else
                Correct();
        }

        /// <summary>
        /// 受击接口
        /// </summary>
        /// <param name="attacker"></param>
        public void Attacked(IAttribute attacker)
        {
            _animator.SetTrigger(AnimatorString.BeAttacked);
            Debug.Log("Attacked");
            //不是暴走状态受击 更新两次
            if (!Mathf.Approximately(_monsterAttribute.GetAttributesValue(EMonsterAttributeType.IsRampage), 1))
            {
                UpdateFixedValue();
                UpdateFixedValue();
            }
            //如果是在暴走状态 则减少愤怒值
            else
            {
                float calmness = attacker.GetAttributesValue(EAttributeType.Calmness);
                _monsterAttribute.SetAttributesValue(EMonsterAttributeType.FixedAnger, -calmness);
                if (_monsterAttribute.GetAttributesValue(EMonsterAttributeType.StartAnger) +
                    _monsterAttribute.GetAttributesValue(EMonsterAttributeType.FixedAnger) <
                    _monsterAttribute.GetAttributesValue(EMonsterAttributeType.CalmnessThreshold))
                {
                    //触发平静状态
                    _monsterAttribute.SetAttributesValue(EMonsterAttributeType.IsRampage, 0);
                    //执行动画
                    _animator.SetTrigger("isCalmness");
                    //触发玩家的属性增加
                    EventManager.Instance.TriggerEvent(new UpdatePlayerAttribute()
                    {
                        attributeType = _monsterAttribute.GetUpgradeAttribute(),
                        varValue = _monsterAttribute.GetAttributesValue(EMonsterAttributeType.UpgradeValue)
                    });
                }
            }
        }

        /// <summary>
        /// 正确的交互
        /// </summary>
        public void Correct()
        {
            //触发平静状态
            _monsterAttribute.SetAttributesValue(EMonsterAttributeType.IsRampage, 0);
            //执行动画
            _animator.SetTrigger("right");
            GetComponent<CapsuleCollider2D>().enabled = false;
        }

        /// <summary>
        /// 错误的交互
        /// </summary>
        private void Wrong()
        {
            UpdateFixedValue();
        }


        /// <summary>
        /// 更新一次变换数值
        /// </summary>
        private void UpdateFixedValue()
        {
            float angerRangeValue = _monsterAttribute.GetAttributesValue(EMonsterAttributeType.AngerIncreaseRate);
            float fixedRangeA = _monsterAttribute.GetAttributesValue(EMonsterAttributeType.ThresholdAChangeRange);
            float fixedRangeB = _monsterAttribute.GetAttributesValue(EMonsterAttributeType.ThresholdBChangeRange);

            float newAngerValue = Random.Range(0, angerRangeValue);
            float newValueA = Random.Range(0, fixedRangeA);
            float newValueB = Random.Range(0, fixedRangeB);

            _monsterAttribute.SetAttributesValue(EMonsterAttributeType.FixedAnger, newAngerValue);
            _monsterAttribute.SetAttributesValue(EMonsterAttributeType.FixedThresholdA, newValueA);
            _monsterAttribute.SetAttributesValue(EMonsterAttributeType.FixedThresholdB, newValueB);

            _monsterAttribute.SetAttributesValue(EMonsterAttributeType.CurrentMistakes, 1);


            //状态检测
            //次数大于等于最大次数 或 愤怒值达到最大 进入愤怒模式
            if (_monsterAttribute.GetAttributesValue(EMonsterAttributeType.CurrentMistakes) >=
                _monsterAttribute.GetAttributesValue(EMonsterAttributeType.MaxMistakes) ||
                _monsterAttribute.GetAttributesValue(EMonsterAttributeType.StartAnger) +
                _monsterAttribute.GetAttributesValue(EMonsterAttributeType.FixedAnger) >= 100)
            {
                _monsterAttribute.SetAttributesValue(EMonsterAttributeType.IsRampage, 1);
                // _animator.SetTrigger("isAngry");
            }
        }
    }
}