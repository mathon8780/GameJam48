using System;
using System.Collections.Generic;
using Tools;
using UnityEngine;
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
        public void RegisterEventListener<T>(UnityAction<T> action)
        {
            if (action == null)
            {
                Debug.LogError("null action");
            }

            Type type = typeof(T);
            if (!_eventDic.ContainsKey(type))
                _eventDic.Add(type, null);

            _eventDic.TryGetValue(type, out var existingDel);
            _eventDic[type] = Delegate.Combine(existingDel, action);
        }

        /// <summary>
        /// 注销事件
        /// </summary>
        /// <param name="action">事件回调</param>
        /// <typeparam name="T">事件类型</typeparam>
        public void UnregisterEventListener<T>(UnityAction<T> action)
        {
            if (action == null)
            {
                Debug.LogError("null action");
                return;
            }

            Type eventType = typeof(T);
            if (!_eventDic.ContainsKey(eventType))
                return;

            _eventDic.TryGetValue(eventType, out var existingDelegate);
            var resultDelegate = Delegate.Remove(existingDelegate, action);
            if (resultDelegate == null)
                _eventDic.Remove(eventType);
            else
            {
                _eventDic[eventType] = resultDelegate;
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
                Debug.Log($"Trigger event: {eventType.Name}");
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