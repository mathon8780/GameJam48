namespace Tools
{
    public class SingleTon<T> where T : class, new()
    {
        private static T _instance; // 存储单例实例
        private static readonly object Lock = new object(); // 用于线程同步，防止多线程访问问题

        /// <summary>
        /// 获取单例实例。如果实例不存在，则创建一个新的实例。
        /// </summary>
        public static T Instance
        {
            get
            {
                // 使用lock确保在多线程环境下只有一个线程能创建实例
                lock (Lock)
                {
                    if (_instance == null)
                    {
                        _instance = new T();
                    }

                    return _instance;
                }
            }
        }
    }
}