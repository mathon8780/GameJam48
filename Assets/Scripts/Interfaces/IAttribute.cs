using DataConfig;

namespace Interfaces
{
    public interface IAttribute
    {
        /// <summary>
        /// 获取属性值
        /// </summary>
        /// <param name="attributeType"></param>
        /// <returns></returns>
        float GetAttributesValue(EAttributeType attributeType);

        /// <summary>
        /// 设置属性值
        /// </summary>
        /// <param name="attributeType">目标属性</param>
        /// <param name="varValue">修改值</param>
        void SetAttributesValue(EAttributeType attributeType, float varValue);

        /// <summary>
        /// 获取玩家状态
        /// </summary>
        /// <returns></returns>
        EPlayerState GetPlayerState();

        /// <summary>
        /// 设置玩家状态
        /// </summary>
        /// <param name="state"></param>
        void SetPlayerState(EPlayerState state);

        /// <summary>
        /// 获取玩家运行时状态
        /// </summary>
        /// <param name="runTimeAttributeType">状态属性</param>
        /// <returns></returns>
        bool GetRunTimeAttributeValue(ERunTimeAttributeType runTimeAttributeType);

        void SetRunTimeAttributeValue(ERunTimeAttributeType runTimeAttributeType, bool value);
    }

    /// <summary>
    /// 玩家基础属性
    /// </summary>
    public enum EAttributeType
    {
        HP,
        MaxHP,
        FixedHP,
        MoveSpeed,
        JumpHeight,
        Calmness,
        Defense
    }

    /// <summary>
    /// 运行时赋予属性
    /// </summary>
    public enum ERunTimeAttributeType
    {
        InInteractiveArea,
        IsGround,
        IsMoving,
        canMove,
        isAlive
    }
}