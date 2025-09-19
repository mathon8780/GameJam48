using UnityEngine;

namespace DataConfig
{
    [CreateAssetMenu(fileName = "New PlayerAttribute", menuName = "Player Attribute", order = 0)]
    public class PlayerAttributes : ScriptableObject
    {
        [Tooltip("血量")] public float Hp;
        [Tooltip("移动速度")] public float MoveSpeed;
        [Tooltip("跳跃高度")] public float JumpHeight;
        [Tooltip("防御力")] public float Defense;
        [Tooltip("冷静力")] public float Calmness;
    }
}