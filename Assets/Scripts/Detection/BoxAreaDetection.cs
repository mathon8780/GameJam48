using System;
using DataConfig;
using Interfaces;
using Tools;
using UnityEngine;

namespace Detection
{
    /// <summary>
    /// 范围检测
    /// 绑定在角色身上 减少检测盒子的使用
    /// </summary>
    public class BoxAreaDetection : MonoBehaviour, IDetectionInteraction
    {
        //玩家的属性操作接口
        IAttribute _playerAttribute;

        //怪物属性接口
        IMonsterAttribute _monsterAttribute;

        //怪物交互接口
        public IReaction _monsterReaction;


        private void Start()
        {
            _playerAttribute = GetComponentInParent<IAttribute>();
            if (_playerAttribute == null)
                Debug.LogError("BoxAreaDetection: IAttribute component not found on the GameObject.");
            
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            //检测到怪物  玩家可互动
            if (other.CompareTag("Monster"))
            {
                _monsterReaction = other.GetComponent<IReaction>();
                _playerAttribute?.SetRunTimeAttributeValue(ERunTimeAttributeType.InInteractiveArea, true);
            }
        }


        private void OnTriggerExit2D(Collider2D other)
        {
            //离开怪物  玩家不可互动
            if (other.CompareTag("Monster"))
            {
                _playerAttribute?.SetRunTimeAttributeValue(ERunTimeAttributeType.InInteractiveArea, false);
            }
        }

        public void TakeInteraction(EInteractiveType type)
        {
            _monsterReaction?.Interactive(type);
        }
    }
}