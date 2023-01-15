using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LightJack.UnityTools.Debugging;
using UnityEngine.UI;

public class DebugModeToggle : MonoBehaviour
{
    public void Toggled()
    {
        bool state = this.GetComponent<Toggle>().isOn;
        SettingsStore.DebugModeEnabled = state;
    }

}
