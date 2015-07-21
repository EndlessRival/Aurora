using UnityEngine;
using System.Collections;

namespace Aurora.Game
{
    public class Main : MonoBehaviour
    {
        // Use this for initialization
        void Start()
        {
            Debug.Log("Main.Start();");
            // this.gameObject.AddComponent<GlobalLogHandler>();

            // test
            Debug.Log("Event name = " + GameEvent.Instance.GetEventNameWithID(GameEvent.EVENT_ID_5));
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}