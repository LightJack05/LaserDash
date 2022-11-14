using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueHandler : MonoBehaviour
{
    public bool IsDialogDisplayed = false;
    public bool IsCurrentDialogCancelable = false;
    List<string> CurrentDialogueTexts = new();
    int currentDialogueText = 0;
    float oldTimeScale = 1;

    public void ShowDialogue(List<string> Texts, bool pauseGameWhileShowing = false, bool isCancelable = false)
    {
        IsDialogDisplayed = true;
        IsCurrentDialogCancelable = isCancelable;
        CurrentDialogueTexts = Texts;
        currentDialogueText = 0;
        this.GetComponent<TextMeshProUGUI>().text = CurrentDialogueTexts[0];
        if (pauseGameWhileShowing)
        {
            oldTimeScale = Time.timeScale;
            Time.timeScale = 0;
        }

    }

    private void Update()
    {
        if (IsDialogDisplayed)
        {
            if (IsCurrentDialogCancelable && Input.GetKeyDown(KeyCode.Escape))
            {
                CancelDialogue();
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                ShowNextDialogueText();
            }
        }
    }

    private void ShowNextDialogueText()
    {
        currentDialogueText++;
        if (currentDialogueText >= CurrentDialogueTexts.Count)
        {
            CloseDialogue();
        }
        else
        {

        this.GetComponent<TextMeshProUGUI>().text = CurrentDialogueTexts[currentDialogueText];
        }
    }

    private void CancelDialogue()
    {
        CloseDialogue();
    }

    private void CloseDialogue()
    {
        this.GetComponent<TextMeshProUGUI>().text = "";
        IsDialogDisplayed = false;
        IsCurrentDialogCancelable = false;
        CurrentDialogueTexts = new();
        currentDialogueText = 0;
        Time.timeScale = oldTimeScale;
        oldTimeScale = 1;
    }
}
