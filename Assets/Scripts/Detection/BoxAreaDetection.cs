using System;
using Interfaces;
using UnityEngine;

namespace Detection
{
    /// <summary>
    /// 范围检测
    /// 绑定在角色身上 减少检测盒子的使用
    /// </summary>
    public class BoxAreaDetection : MonoBehaviour
    {
        //玩家的属性操作接口
        IAttribute _playerAttribute;


        private void Start()
        {
            _playerAttribute = GetComponent<IAttribute>();
            if (_playerAttribute == null)
                Debug.LogError("BoxAreaDetection: IAttribute component not found on the GameObject.");
        }


        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Monster"))
            {
                // _playerAttribute = other.GetComponent<IAttribute>();
                _playerAttribute?.SetRunTimeAttributeValue(ERunTimeAttributeType.InInteractiveArea, true);
            }
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            if (other.collider.CompareTag("Monster"))
            {
                // _playerAttribute = other.collider.GetComponent<IAttribute>();
                _playerAttribute?.SetRunTimeAttributeValue(ERunTimeAttributeType.InInteractiveArea, false);
            }
        }
    }
}