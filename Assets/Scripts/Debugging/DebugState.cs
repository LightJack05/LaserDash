using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace LightJack.UnityTools.Debugging
{
    public static class DebugState
    {
        public static bool DebugModeEnabled { get; private set; } = false;

        public static void EnableDebugMode(GameObject debugMenu, GameObject player)
        {
            DebugModeEnabled = true;
            debugMenu.SetActive(true);
        }

        public static void DisableDebugMode(GameObject debugMenu, GameObject player)
        {
            DebugModeEnabled = false;
            debugMenu.SetActive(false);
        }

    }
}


