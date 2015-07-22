using UnityEngine;
using System.Collections;
using Aurora.Framework.Util;

namespace Aurora.Game
{
    public class Main : MonoBehaviour
    {
        // Use this for initialization
        void Start()
        {
            Debug.LogError("Error test");
            // this.gameObject.AddComponent<GlobalLogHandler>();

            // DebugUtils.Assert(false, "Test assert!");

            Debug.Assert(false, "Debug.Assert");
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}