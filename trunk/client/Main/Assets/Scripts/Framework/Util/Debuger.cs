using UnityEngine;

namespace Aurora.Framework.Util
{
    public sealed class Debuger
    {
        /// <summary>
        /// 调试系统开关
        /// </summary>
        public static bool s_active = true;

        /// <summary>
        /// 禁止外部实例化
        /// </summary>
        private Debuger()
        {

        }

        /// <summary>
        /// 断言
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="message"></param>
        public static void Assert(bool condition, string message)
        {
            if (!s_active) return;

            Debug.Assert(condition, message);

            if (!condition)
            {
#if UNITY_EDITOR || UNITY_STANDALONE_WIN
                Debug.Break();
#endif
            }
        }

        /// <summary>
        /// 普通日志
        /// </summary>
        /// <param name="message"></param>
        public static void Log(string message)
        {
            if (!s_active) return;
            Debug.Log(message);
        }

        /// <summary>
        /// 警告日志
        /// </summary>
        /// <param name="message"></param>
        public static void LogWarning(string message)
        {
            if (!s_active) return;
            Debug.LogWarning(message);
        }

        /// <summary>
        /// 错误日志
        /// </summary>
        /// <param name="message"></param>
        public static void LogError(string message)
        {
            if (!s_active) return;
            Debug.LogError(message);
        }
    }
}