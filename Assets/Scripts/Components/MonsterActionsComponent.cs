using DataConfig;
using Interfaces;
using UnityEngine;

namespace Components
{
    public class MonsterActionsComponent : MonoBehaviour, IReaction
    {
        /// <summary>
        /// 产生交互接口
        /// </summary>
        /// <param name="interactiveType"></param>
        public void Interactive(EInteractiveType interactiveType)
        {
        }

        /// <summary>
        /// 受击接口
        /// </summary>
        /// <param name="attacker"></param>
        public void Attacked(IAttribute attacker)
        {
        }
    }
}