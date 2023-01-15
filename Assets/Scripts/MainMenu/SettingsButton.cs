using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsButton : MonoBehaviour
{
    public GameObject SettingsMenu;
    public void OpenSettings()
    {
        SettingsMenu.SetActive(true);
    }
}
