using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CalculatorEqualsButtonBehaviour : MonoBehaviour
{
    GameObject CalculatorTextBox;
    int failCounter = 0;
    float shakeMagnitude = 0.1f;
    private void Start()
    {
        CalculatorTextBox = GameObject.FindGameObjectWithTag("CalculatorDisplayText");
    }

    public void OnButtonClick()
    {
        CalculatorTextBox.GetComponent<TextMeshProUGUI>().text = "Error: \"System.OperationNotPermitted\" Please try again.";
        failCounter++;
        if(failCounter >= 3)
        {
            StartCoroutine(Camera.main.GetComponent<ObjectShake>().ShakeObject(2f, 0.8f));
            Invoke("LoadNextScene", 2f);
        }
        else
        {
            StartCoroutine(Camera.main.GetComponent<ObjectShake>().ShakeObject(0.3f, shakeMagnitude));
            shakeMagnitude += 0.1f;
        }
        
    }

    void LoadNextScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("CrashScene");
    }

}
