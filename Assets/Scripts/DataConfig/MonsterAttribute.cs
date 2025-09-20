using Interfaces;
using UnityEngine;

namespace DataConfig
{
    [CreateAssetMenu(fileName = "New MonsterAttribute", menuName = "MonsterAttribute", order = 0)]
    public class MonsterAttribute : ScriptableObject
    {
        [Tooltip("移动速度")] public float MoveSpeed;
        [Tooltip("左侧移动距离")] public float LeftDistance;
        [Tooltip("右侧移动距离")] public float RightDistance;

        [Tooltip("初始愤怒值/红温度")] public float StartAnger;
        [Tooltip("修正愤怒值/红温度")] public float FixedAnger = 0;
        [Tooltip("初始修正范围")] public float StartChangeRange;

        [Tooltip("阈值A")] public float ThresholdA;
        [Tooltip("变换范围A")] public float ThresholdAChangeRange;
        [Tooltip("修正阈值A 默认0")] public float FixedThresholdA = 0;

        [Tooltip("阈值B")] public float ThresholdB;
        [Tooltip("变换范围B")] public float ThresholdBChangeRange;
        [Tooltip("修正阈值B 默认0")] public float FixedThresholdB = 0;

        [Tooltip("最大错误次数")] public int MaxMistakes;
        [Tooltip("当前错误次数 默认0")] public int CurrentMistakes = 0;

        [Tooltip("攻击力")] public float Atk;
        [Tooltip("红温增幅")] public float AngerIncreaseRate;
        [Tooltip("冷静阈值 默认40")] public float CalmnessThreshold = 40;

        [Tooltip("怪物状态")] public EMonsterState MonsterState = EMonsterState.Idle;
        [Tooltip("暴走状态")] public bool IsRampage = false;

        [Header("击败回复")] [Tooltip("升级增加属性")] public EUpgradeAttribute UpgradeAttribute;
        [Tooltip("升级增加数值")] public float UpgradeValue;
    }
}