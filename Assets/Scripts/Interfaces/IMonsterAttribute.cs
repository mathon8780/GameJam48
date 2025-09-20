using DataConfig;

namespace Interfaces
{
    public interface IMonsterAttribute
    {
        /// <summary>
        /// 获取属性值
        /// </summary>
        /// <param name="attributeType"></param>
        /// <returns></returns>
        float GetAttributesValue(EMonsterAttributeType attributeType);

        /// <summary>
        /// 设置属性值
        /// </summary>
        /// <param name="attributeType">目标属性</param>
        /// <param name="varValue">修改值</param>
        void SetAttributesValue(EMonsterAttributeType attributeType, float varValue);

        /// <summary>
        /// 获取怪物状态
        /// </summary>
        /// <returns></returns>
        EMonsterState GetMonsterState();

        /// <summary>
        /// 设置怪物状态
        /// </summary>
        /// <param name="state"></param>
        void SetMonsterState(EMonsterState state);

        /// <summary>
        /// 获得升级增加属性
        /// </summary>
        /// <returns></returns>
        EUpgradeAttribute GetUpgradeAttribute();
    }

    /// <summary>
    /// 怪物基础属性
    /// </summary>
    public enum EMonsterAttributeType
    {
        MoveSpeed, //移动速度
        LeftDistance, //左侧移动距离
        RightDistance, //右侧移动距离
        StartAnger, //初始愤怒值
        FixedAnger, //修正愤怒值
        StartChangeRange, //初始变化范围
        ThresholdA, //阈值A
        ThresholdAChangeRange, //A变换范围
        FixedThresholdA, //修正阈值A
        ThresholdB, //阈值B
        ThresholdBChangeRange, //B变换范围
        FixedThresholdB, //修正阈值B
        MaxMistakes, //最大错误次数
        CurrentMistakes, //当前错误次数
        Atk, //攻击力
        AngerIncreaseRate, //愤怒增长速率
        CalmnessThreshold, //冷静阈值
        IsRampage, //暴走状态
        UpgradeAttribute, //升级增加属性
        UpgradeValue //升级增加数值
    }
}