namespace Aurora.Framework.Util
{
    /// <summary>
    /// Singleton模板（线程安全）
    /// [注意]
    /// T必须为class，并拥有公有的无参数构造函数
    /// </summary>
    public class Singleton<T> where T : class, new()
    {
        private static T s_instance;
        private static object s_lock = new object();

        public static T Instance
        {
            get
            {
                // Double-Checked Locking
                // 避免不要的锁开销
                if (s_instance == null)
                {
                    lock (s_lock)
                    {
                        s_instance = new T();
                    }
                }
                return s_instance;
            }
        }
    }
}