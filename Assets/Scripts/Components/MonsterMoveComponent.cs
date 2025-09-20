using DataConfig;
using Interfaces;
using System;
using UnityEngine;

namespace Components
{
    /// <summary>
    /// 怪物移动脚本
    /// </summary>
    public class MonsterMoveComponent : MonoBehaviour
    {
        IMonsterAttribute _monsterAttribute;
        [Tooltip("移动速度")] public float speed = 5f;
        [Tooltip("从中心点向左移动的最大距离")] public float leftDistance;
        [Tooltip("从中心点向右移动的最大距离")] public float rightDistance;
        [Tooltip("当前的移动状态")] public MoveState moveState = MoveState.MoveRight; // 初始状态可以设置为向右移动

        private Vector2 _defaultPosition; // 初始中心位置
        private Vector2 _leftTargetPosition; // 左侧目标位置
        private Vector2 _rightTargetPosition; // 右侧目标位置

        void Start()
        {
            _monsterAttribute = GetComponent<IMonsterAttribute>();
            leftDistance = _monsterAttribute.GetAttributesValue(EMonsterAttributeType.LeftDistance);
            rightDistance = _monsterAttribute.GetAttributesValue(EMonsterAttributeType.RightDistance);

            // 获取并保存初始位置作为中心点
            _defaultPosition = transform.position;

            // 计算左右两边的目标位置
            _leftTargetPosition = new Vector2(_defaultPosition.x - leftDistance, _defaultPosition.y);
            _rightTargetPosition = new Vector2(_defaultPosition.x + rightDistance, _defaultPosition.y);

            // 确保初始状态不是Idle，否则物体不会移动
            if (moveState == MoveState.Idle)
            {
                moveState = MoveState.MoveLeft; // 默认开始向右移动
            }
        }

        private void Update()
        {
            speed = _monsterAttribute.GetAttributesValue(EMonsterAttributeType.MoveSpeed);
            // 根据当前状态进行移动
            if (moveState == MoveState.MoveLeft)
            {
                //_monsterAttribute.SetMonsterState(EMonsterState.Patrol);
                // 向左移动
                transform.position = Vector2.MoveTowards(transform.position, _leftTargetPosition, speed * Time.deltaTime);

                // 如果到达或超过左侧目标点，则切换到向右移动
                if (transform.position.x <= _leftTargetPosition.x)
                {
                    transform.localScale = new Vector2(-1f, transform.localScale.y);
                    moveState = MoveState.MoveRight;
                }
            }
            else if (moveState == MoveState.MoveRight)
            {
                // 向右移动
                transform.position = Vector2.MoveTowards(transform.position, _rightTargetPosition, speed * Time.deltaTime);

                // 如果到达或超过右侧目标点，则切换到向左移动
                if (transform.position.x >= _rightTargetPosition.x)
                {
                    transform.localScale = new Vector2(1f, transform.localScale.y);
                    moveState = MoveState.MoveLeft;
                }
            }
            // 如果是Idle状态，则不做任何移动
        }
    }

    public enum MoveState
    {
        Idle, // 停止不动
        MoveLeft, // 向左移动
        MoveRight // 向右移动
    }
}