using UnityEngine;

namespace DataConfig
{
    [CreateAssetMenu(fileName = "New MonsterAttribute", menuName = "MonsterAttribute", order = 0)]
    public class MonsterAttribute : ScriptableObject
    {
        [Tooltip("初始素质值")] public float StartQuality;
        [Tooltip("修正素质值")] public float FixedQuality = 0;

        [Tooltip("阈值A")] public float ThresholdA;
        [Tooltip("变换范围A")] public float ThresholdAChangeRange;
        [Tooltip("修正阈值A 默认0")] public float FixedThresholdA = 0;

        [Tooltip("阈值B")] public float ThresholdB;
        [Tooltip("变换范围B")] public float ThresholdBChangeRange;
        [Tooltip("修正阈值B 默认0")] public float FixedThresholdB = 0;

        [Tooltip("最大错误次数")] public int MaxMistakes;
        [Tooltip("当前错误次数 默认0")] public int CurrentMistakes = 0;

        [Tooltip("攻击力")] public float Atk;
        [Tooltip("愤怒值/红温度")] public float Rage;
        [Tooltip("冷静阈值 默认40")] public float CalmnessThreshold = 40;
    }
}