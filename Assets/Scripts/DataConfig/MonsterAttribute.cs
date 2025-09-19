using UnityEngine;

namespace DataConfig
{
    [CreateAssetMenu(fileName = "New MonsterAttribute", menuName = "MonsterAttribute", order = 0)]
    public class MonsterAttribute : ScriptableObject
    {
        [Tooltip("初始素质值")] public float StartQuality;
        [Tooltip("阈值A")] public float ThresholdA;
        [Tooltip("变换范围A")] public float ThresholdAChangeRange;
        [Tooltip("阈值B")] public float ThresholdB;
        [Tooltip("变换范围B")] public float ThresholdBChangeRange;
        [Tooltip("最大错误次数")] public int MaxMistakes;
        [Tooltip("攻击力")] public float Atk;
        [Tooltip("愤怒值")] public float Rage;
        [Tooltip("冷静阈值")] public float CalmnessThreshold;
    }
}