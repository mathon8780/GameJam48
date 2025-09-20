using System;
using Interfaces;
using TreeEditor;
using UnityEngine;

namespace Components
{
    public class MonsterCollisionDamage : MonoBehaviour
    {
        IAttribute _playerAttribute;
        IMonsterAttribute _monsterAttribute;
        Animator _monsterAnimator;
        private float lastAttackTime; //上一次攻击时间
        private float atkDistance = 1; //攻击距离
        private float atkInterval = 2; //攻击间隔

        private void Start()
        {
            lastAttackTime = Time.time;
            _monsterAttribute = GetComponentInParent<IMonsterAttribute>();
            _monsterAnimator = GetComponentInParent<Animator>();
        }

        /// <summary>
        /// 动画触发事件
        /// </summary>
        /// <param name="other"></param>
        private void OnTriggerEnter2D(Collider2D other)
        {
            //todo:统一配置属性获取
            if (other.CompareTag("Player") && lastAttackTime + atkInterval < Time.time)
            {
                if ((other.gameObject.transform.position - gameObject.transform.position).magnitude > atkDistance) return;

                _monsterAnimator.SetTrigger("attack"); //播放攻击动画
                lastAttackTime = Time.time; //更新攻击时间
                //获得属性接口
                _playerAttribute = other.GetComponent<IAttribute>();
                float atk = _monsterAttribute.GetAttributesValue(EMonsterAttributeType.Atk);
                float defense = _playerAttribute.GetAttributesValue(EAttributeType.Defense);
                float damage = atk - defense;
                _playerAttribute.SetAttributesValue(EAttributeType.HP, -damage);
            }
        }
    }
}