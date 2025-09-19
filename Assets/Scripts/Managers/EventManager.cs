using System;
using System.Collections.Generic;
using Tools;
using UnityEngine.Events;

namespace Managers
{
    public class EventManager : SingleTonMono<EventManager>
    {
        private Dictionary<Type, Delegate> _eventDic = new();


        /// <summary>
        /// 注册事件
        /// </summary>
        /// <param name="action">事件回调</param>
        /// <typeparam name="T">事件类型</typeparam>
        public void RegisterEventListener<T>(UnityAction action)
        {
            Type eventType = typeof(T);
            if (!_eventDic.ContainsKey(eventType))
                _eventDic.Add(eventType, null);

            _eventDic[eventType] = Delegate.Combine(_eventDic[eventType], action);
        }

        /// <summary>
        /// 注销事件
        /// </summary>
        /// <param name="action">事件回调</param>
        /// <typeparam name="T">事件类型</typeparam>
        public void UnregisterEventListener<T>(UnityAction action)
        {
            Type eventType = typeof(T);
            if (_eventDic.ContainsKey(eventType))
            {
                var currentDel = Delegate.Remove(_eventDic[eventType], action);
                if (currentDel == null)
                    _eventDic.Remove(eventType);
                else
                    _eventDic[eventType] = currentDel;
            }
        }

        /// <summary>
        /// 触发事件-有参
        /// </summary>
        /// <param name="content">事件内容</param>
        /// <typeparam name="T">事件类型</typeparam>
        public void TriggerEvent<T>(T content)
        {
            Type eventType = typeof(T);
            if (_eventDic.TryGetValue(eventType, out var existingDelegate))
            {
                (existingDelegate as UnityAction<T>)?.Invoke(content);
            }
        }

        /// <summary>
        /// 触发事件-无参
        /// </summary>
        /// <typeparam name="T">事件类型</typeparam>
        public void TriggerEvent<T>() where T : new()
        {
            TriggerEvent(new T());
        }
    }
}