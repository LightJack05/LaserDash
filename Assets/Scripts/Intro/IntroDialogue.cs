using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IntroDialogue : MonoBehaviour
{
    public GameObject TextBox;
    List<string> textList = new List<string>()
    {
        "Use [SPACE] to move though dialogs.",
        "Hmm... Who threw this disk into my Letter Box?",
        "Let's find out I guess...",
        "Hmm... \"Secrets.exe\"... I wonder what that's all about.",
        "Let's just open it."
    };
    private void Start()
    {
        this.GetComponent<DialogueHandler>().ShowDialogue(textList, false, false);
    }

    private void Update()
    {
        if(this.GetComponent<DialogueHandler>().IsDialogDisplayed == false)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("CalculatorScene");
        }
    }


}
