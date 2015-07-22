using System.Collections.Generic;
using Aurora.Framework.Util;

namespace Aurora.Game
{
    public class EventBase
    {
        private static int s_id = 0;
        private static Dictionary<int, string> m_eventNameDict = new Dictionary<int, string>();
        private static int GenerateEventID(string eventName)
        {
            Debuger.Assert(!string.IsNullOrEmpty(eventName), 
                "EventBase.GenerateEventID: Event name must not be null!");

            int ret = s_id++;
            m_eventNameDict[ret] = eventName;
            return ret;
        }
    }

    public class CustomEvent : EventBase
    {

    }
}
