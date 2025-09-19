namespace Interfaces
{
    public interface IActions
    {
        /// <summary>
        /// 问候
        /// </summary>
        void Greeting();

        /// <summary>
        /// 交谈
        /// </summary>
        void Chat();

        /// <summary>
        /// 吼叫
        /// </summary>
        void Roar();

        /// <summary>
        /// 攻击
        /// </summary>
        void Attack();
    }
}