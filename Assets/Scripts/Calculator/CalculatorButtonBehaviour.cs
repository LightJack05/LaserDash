using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CalculatorButtonBehaviour : MonoBehaviour
{
    GameObject CalculatorTextBox;
    public string ButtonContent;
    private void Start()
    {
        CalculatorTextBox = GameObject.FindGameObjectWithTag("CalculatorDisplayText");
    }
    public void OnButtonClick()
    {
        if(CalculatorTextBox.GetComponent<TextMeshProUGUI>().text == "Error: \"System.OperationNotPermitted\" Please try again.")
        {
            CalculatorTextBox.GetComponent<TextMeshProUGUI>().text = "";
        }
        CalculatorTextBox.GetComponent<TextMeshProUGUI>().text += ButtonContent;
    }
}
