using DataConfig;

namespace Interfaces
{
    public interface IAttribute
    {
        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="attributeType"></param>
        /// <returns></returns>
        float GetAttributesValue(EAttributeType attributeType);

        EPlayerState GetPlayerState();
    }

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
}