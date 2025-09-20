using System;
using DataConfig;
using Interfaces;
using UnityEngine;

namespace Components
{
    public class MonsterActionsComponent : MonoBehaviour, IReaction
    {
        IMonsterAttribute _monsterAttribute;


        private void Start()
        {
            _monsterAttribute = GetComponent<IMonsterAttribute>();
            if (_monsterAttribute == null)
                Debug.LogError("MonsterActionsComponent: IMonsterAttribute component not found on the GameObject.");
        }

        /// <summary>
        /// 产生交互接口
        /// </summary>
        /// <param name="interactiveType"></param>
        public void Interactive(EInteractiveType interactiveType)
        {
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
            else if (startAnger + fixedAnger > thresholdA && startAnger + fixedAnger <= thresholdB)
            {
                targetType = EInteractiveType.Chat;
            }
            //第三个区间
            else if (startAnger + fixedAnger > thresholdB + fixedThresholdB)
            {
                targetType = EInteractiveType.Roar;
            }

            if (interactiveType != targetType)
            {
                _monsterAttribute.SetAttributesValue(EMonsterAttributeType.CurrentMistakes, 1);
            }
            else
            {
                CorrectCorrect();
            }
        }


        /// <summary>
        /// 受击接口
        /// </summary>
        /// <param name="attacker"></param>
        public void Attacked(IAttribute attacker)
        {
        }

        /// <summary>
        /// 正确的交互
        /// </summary>
        public void CorrectCorrect()
        {
        }
    }
}