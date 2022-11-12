using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IntroTextScrolling : MonoBehaviour
{
    int currentText = 0;
    public GameObject TextBox;
    List<string> textList = new List<string>()
    {
        "Hmm... Who threw this disk into my Letter Box?",
        "Let's find out I guess...",
        "Hmm... \"Secrets.exe\"... I wonder what that's all about.",
        "Let's just open it."
    };
    private void Start()
    {
        TextBox.GetComponent<TextMeshProUGUI>().text = textList[currentText];
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))
        {
            ShowNextText();
        }
    }

    void ShowNextText()
    {
        currentText++;
        if(currentText >= textList.Count)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("CalculatorScene");
        }
        TextBox.GetComponent<TextMeshProUGUI>().text = textList[currentText];
    }
}
