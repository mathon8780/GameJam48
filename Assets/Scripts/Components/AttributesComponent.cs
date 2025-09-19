using System;
using DataConfig;
using Interfaces;
using UnityEngine;

namespace Components
{
    public class AttributesComponent : MonoBehaviour, IAttribute
    {
        [SerializeField] private PlayerAttributes attributes;

        public float GetAttributesValue(EAttributeType attributeType)
        {
            switch (attributeType)
            {
                case EAttributeType.HP:
                    return attributes.Hp + attributes.FixedHp;
                case EAttributeType.MaxHP:
                    return attributes.MaxHp;
                case EAttributeType.FixedHP:
                    return attributes.FixedHp;
                case EAttributeType.MoveSpeed:
                    return attributes.MoveSpeed;
                case EAttributeType.JumpHeight:
                    return attributes.JumpHeight;
                case EAttributeType.Calmness:
                    return attributes.Calmness;
                case EAttributeType.Defense:
                    return attributes.Defense;
            }

            return 0;
        }

        public EPlayerState GetPlayerState()
        {
            return attributes.playerState;
        }
    }
}