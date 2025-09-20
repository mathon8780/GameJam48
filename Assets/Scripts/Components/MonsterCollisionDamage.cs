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

        private void Start()
        {
            _monsterAttribute = GetComponentInParent<IMonsterAttribute>();
            _monsterAnimator = GetComponentInParent<Animator>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            //todo:统一配置属性获取
            if (other.CompareTag("Player") && _monsterAnimator.GetBool("isAnger"))
            {
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