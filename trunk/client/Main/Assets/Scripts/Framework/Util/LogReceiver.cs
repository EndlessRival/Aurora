using UnityEngine;
using System;
using System.Collections.Generic;

namespace Aurora.Framework.Util
{
    /// <summary>
    /// 日志接收器
    /// </summary>
    public class LogReceiver : MonoBehaviour
    {
        /// <summary>
        /// 日志信息结构
        /// </summary>
        private struct LogStruct
        {
            public string condition;
            public string stackTrace;
            public LogType logType;
            public int count;
        }

        /// <summary>
        /// 日志字典，记录详细的日志数据
        /// </summary>
        private static Dictionary<string, LogStruct> s_logDict = new Dictionary<string, LogStruct>();

        /// <summary>
        /// 注册日志接收函数
        /// </summary>
        void Awake()
        {
            Application.logMessageReceived += Callback;
        }

        private void Callback(string condition, string stackTrace, LogType type)
        {
            switch (type)
            {
                case LogType.Assert:
                case LogType.Error:
                case LogType.Exception:
                    {
                        if (!s_logDict.ContainsKey(condition))
                        {
                            LogStruct log;
                            log.condition = condition;
                            log.stackTrace = stackTrace;
                            log.logType = type;
                            log.count = 1;
                            s_logDict.Add(condition, log);

                            // Send to server
                        }
                    } break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 反注册日志接收函数
        /// </summary>
        void OnDestroy()
        {
            Application.logMessageReceived -= Callback;
        }
    }
}