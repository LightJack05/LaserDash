using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsCloseButton : MonoBehaviour
{
    public GameObject SettingsMenu;

    public void CloseSettings()
    {
        SettingsMenu.SetActive(false);
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            CloseSettings();
        }
    }
}
