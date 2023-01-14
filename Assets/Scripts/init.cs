using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class init : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(Application.platform == RuntimePlatform.Android)
        {
            Application.targetFrameRate = 120;
        }
    }
}
