using UnityEngine;
//using System.Numerics;

namespace Managers
{
    public class EventTypes
    {
    }

    public class HpChanged
    {
        public float CurrentHP;
        public float MaxHP;

        public HpChanged(float currentHP, float maxHP)
        {
            CurrentHP = currentHP;
            MaxHP = maxHP;
        }
    }


    public struct CalmnessChanged
    {
        public float CurrentCalmness;

        public CalmnessChanged(float currentCalmness)
        {
            CurrentCalmness = currentCalmness;
        }
    }

    /********************输入相关**********************/
    // 移动事件
    public struct MoveEvent
    {
        public Vector2 moveInput;
        public MoveEvent(Vector2 moveInput)
        {
            this.moveInput = moveInput;
        }
    }
    // 跳跃事件
    public struct JumpEvent
    {
    }
    // 交互
    // 打招呼事件
    public struct GreetingEvent
    {
    }
    // 聊天事件
    public struct ChatEvent
    {
    }
    // 咆哮事件
    public struct RoarEvent
    {
    }
    /********************输入相关**********************/
}