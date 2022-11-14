using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueStart : MonoBehaviour
{
    List<string> DialogueTexts = new()
    {
        "What? A... calculator?!",
        "I expected more to be honest...",
        "This can't be it, let's poke around in it a bit..."
    };
    public GameObject BlockCalcUI;

    private void Start()
    {
        Invoke("StartDialogue", 0.5f);
    }
    private void StartDialogue()
    {
        this.GetComponent<DialogueHandler>().ShowDialogue(DialogueTexts);
    }

    private void Update()
    {
        if(this.GetComponent<DialogueHandler>().IsDialogDisplayed == false)
        {
            BlockCalcUI.SetActive(false);
        }
    }
}
