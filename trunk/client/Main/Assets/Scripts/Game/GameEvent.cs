using System;
using System.Reflection;
using Aurora.Framework.Util;

namespace Aurora.Game
{
    public class GameEvent : Singleton<GameEvent>
    {
        #region EVENT_BEGIN
        /// <summary>
        /// [注意]
        /// GetEventNameWithID需要使用EVENT_BEGIN定位消息变量的起始位置，
        /// 所以EVENT_BEGIN变量不能被修改。
        /// </summary>
        public static readonly int EVENT_BEGIN = GenerateEventID();
        #endregion

        /// <summary>
        /// [注意]
        /// 消息命名规范：事件ID必须以EVENT_开头，单词以“_”分隔。
        /// </summary>

        #region Test Messages
        public static readonly int EVENT_ID_1 = GenerateEventID();
        public static readonly int EVENT_ID_2 = GenerateEventID();
        public static readonly int EVENT_ID_3 = GenerateEventID();
        public static readonly int EVENT_ID_4 = GenerateEventID();
        public static readonly int EVENT_ID_5 = GenerateEventID();
        #endregion

        #region EVENT_END
        /// <summary>
        /// [注意]
        /// GetEventNameWithID需要使用EVENT_END定位消息变量的结束位置，
        /// 所以EVENT_END变量不能被修改。
        /// </summary>
        public static readonly int EVENT_END = GenerateEventID();
        #endregion

        private static int s_id = 0;
        private static int GenerateEventID()
        {
            int rst = s_id++;
            return rst;
        }

        public string GetEventNameWithID(int id)
        {
            FieldInfo[] fields = GetType().GetFields();

            int begin = 0, end = 0;
            for (int i = 0; i < fields.Length; ++i)
            {
                if (fields[i].Name == "EVENT_BEGIN")
                {
                    begin = i;
                }
                else if (fields[i].Name == "EVENT_END")
                {
                    end = i;
                    break;
                }
            }

            int index = begin + id;

            if (index > 0 && index < end)
            {
                return fields[index].Name;
            }
            else
            {
                throw new Exception("Can not find event with id = " + id);
            }
        }
    }
}
