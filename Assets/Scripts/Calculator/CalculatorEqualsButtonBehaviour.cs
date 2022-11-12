using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

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
            Debug.Log("Calculator section passed.");
        }
        else
        {
            StartCoroutine(Camera.main.GetComponent<ObjectShake>().ShakeObject(0.3f, shakeMagnitude));
            shakeMagnitude += 0.1f;
        }
        
    }

}
