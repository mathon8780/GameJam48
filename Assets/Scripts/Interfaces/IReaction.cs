using DataConfig;

namespace Interfaces
{
    /// <summary>
    /// 敌人的交互接口
    /// </summary>
    public interface IReaction
    {
        /// <summary>
        /// 产生交互
        /// </summary>
        /// <param name="interactiveType">交互类型</param>
        void Interactive(EInteractiveType interactiveType);

        /// <summary>
        /// 受击
        /// </summary>
        /// <param name="attacker">攻击者</param>
        void Attacked(IAttribute attacker);
    }
}