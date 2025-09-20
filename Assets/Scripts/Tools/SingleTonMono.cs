using UnityEngine;

namespace Tools
{
    public class SingleTonMono<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T _instance; // 存储单例实例
        private static readonly object Lock = new object(); // 用于线程同步，防止多线程访问问题
        private static bool _applicationIsQuitting = false; // 标记应用程序是否正在退出

        /// <summary>
        /// 获取单例实例。如果实例不存在，则在场景中查找或创建一个新的GameObject并添加该组件。
        /// </summary>
        public static T Instance
        {
            get
            {
                // 如果应用程序正在退出，不再创建新的实例，直接返回null
                if (_applicationIsQuitting)
                {
                    // Debug.LogWarning($"[Singleton] Instance '{typeof(T)}' already destroyed on application quit. Returning null.");
                    return default;
                }

                // 使用lock确保在多线程环境下只有一个线程能创建实例
                lock (Lock)
                {
                    if (_instance == null)
                    {
                        // 尝试在场景中查找现有实例
                        _instance = (T)FindObjectOfType(typeof(T));
                        // 如果找到多个实例，说明有错误，只使用第一个
                        if (FindObjectsOfType(typeof(T)).Length > 1)
                        {
                            Debug.LogError(
                                $"[Singleton] Something went really wrong - there should never be more than 1 singleton of type {typeof(T).Name}! Reopening the scene might fix it.");
                            return _instance;
                        }

                        // 如果场景中没有找到实例，则创建一个新的GameObject并添加组件
                        if (_instance == null)
                        {
                            GameObject singletonObject = new GameObject();
                            _instance = singletonObject.AddComponent<T>();
                            singletonObject.name = typeof(T).Name + " (Singleton)"; // 命名GameObject以便识别

                            // 确保实例在场景切换时不会被销毁
                            DontDestroyOnLoad(singletonObject);
                            Debug.Log($"[Singleton] A new instance of {typeof(T).Name} was created on demand.");
                        }
                        else
                        {
                            Debug.Log($"[Singleton] Using existing instance of {typeof(T).Name}: {_instance.gameObject.name}");
                            // 确保现有实例也被标记为DontDestroyOnLoad，以防它是手动放置但未设置的
                            DontDestroyOnLoad(_instance.gameObject);
                        }
                    }

                    return _instance;
                }
            }
        }

        /// <summary>
        /// Unity生命周期函数：在对象被加载时调用，用于初始化单例。
        /// </summary>
        protected virtual void Awake()
        {
            if (_instance == null)
            {
                _instance = this as T; // 设置当前实例为单例
                DontDestroyOnLoad(gameObject); // 确保实例在场景切换时不会被销毁
            }
            else if (_instance != this)
            {
                // 如果已经存在一个实例，并且当前实例不是那个实例，则销毁当前重复的GameObject
                Debug.LogWarning($"[Singleton] Duplicate instance of {typeof(T).Name} found. Destroying {gameObject.name}.");
                Destroy(gameObject);
            }
        }

        /// <summary>
        /// Unity生命周期函数：在对象被销毁时调用。
        /// 用于在应用程序退出时清除单例引用，防止在退出后再次访问时创建“幽灵”对象。
        /// </summary>
        protected virtual void OnDestroy()
        {
            if (_instance == this)
            {
                _applicationIsQuitting = true; // 标记应用程序正在退出
                _instance = null; // 清除引用
            }
        }
    }
}