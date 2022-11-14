using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextDrawing : MonoBehaviour
{
    bool animationConpleted = false;
    bool isChatActive = true;
    public GameObject TextField;
    int currentMessage = 12;
    List<string> textList = new List<string>()
    {
@"  Unhandled exception. System.FormatException: Input string was not in a correct format.
                at System.Number.ThrowOverflowOrFormatException(ParsingStatus status, TypeCode type)
                at System.Convert.ToInt32(String value)
                at SecretData.Program.GenerateKey(String key) in C:\\encrypted\\decryptor\\Program.cs:line 831
                at SecretData.Program.EncryptionHandler() in C:\\encrypted\\decryptor\\Program.cs:line 327
                at SecretData.Program.SystemReserverd() in C:\\encrypted\\decryptor\\Program.cs:line 922
                at SecretData.Program.MainFuctionCrashPad() in C:\\encrypted\\decryptor\\Program.cs:line 172
                at SecretData.Program.SystemCall() in C:\\encrypted\\decryptor\\Program.cs:line 129
                at SecretData.Program.Main(String[] args) in C:\\encrypted\\decryptor\\Program.cs:line 347",
        "",
        "Irrecoverable crash...",
        "Initiating emergency procedures...",
        "Connecting to server...",
        "Handshake successfull!",
        "Sending location data...",
        "Gathering system info...",
        "Aquiring chat connection",
        "Connected!",
        "-------------------------------------------[Begin of conversation]-------------------------------------------",
        "Agent> WHAT HAVE YOU DONE?!",
        "Agent> NOBODY WAS SUPPOSED TO FIND THIS DISK!",
        "Agent> YOU ARE IN BIG TROUBLE!",
        "You>   But... What did I do? What happened here?!",
        "Agent> You touched the subcode!",
        "You>   What the hell is a \"subcode\"?!",
        "Agent> You'll find out soon enough... I need to go!",
        "Agent disconnected...",
        "--------------------------------------------[End of conversation]---------------------------------------------",
        "Process Terminated...",
    };

    private void Start()
    {
        StartCoroutine(PlayText());
    }
    private void Update()
    {
        if(animationConpleted && Input.GetKeyDown(KeyCode.Space) && isChatActive)
        {
            NextChatMessage();
        }
    }

    public IEnumerator PlayText()
    {
        yield return new WaitForSeconds(1.5f);
        TextField.GetComponent<TextMeshProUGUI>().text += textList[0] + Environment.NewLine;
        for (int i = 0; i < 7; i++)
        {
            yield return new WaitForSeconds(1f);
            TextField.GetComponent<TextMeshProUGUI>().text += textList[i + 1] + Environment.NewLine;
        }
        yield return new WaitForSeconds(1.2f);
        TextField.GetComponent<TextMeshProUGUI>().text += textList[8];
        for (int i = 0; i < 6; i++)
        {
            yield return new WaitForSeconds(1.2f);
            TextField.GetComponent<TextMeshProUGUI>().text += ".";
        }
        TextField.GetComponent<TextMeshProUGUI>().text += Environment.NewLine;
        yield return new WaitForSeconds(1.4f);
        TextField.GetComponent<TextMeshProUGUI>().text += textList[9] + Environment.NewLine;
        yield return new WaitForSeconds(1.4f);
        TextField.GetComponent<TextMeshProUGUI>().text += textList[10] + Environment.NewLine;
        yield return new WaitForSeconds(1.4f);
        TextField.GetComponent<TextMeshProUGUI>().text += textList[11] + Environment.NewLine;
        animationConpleted = true;

    }


    void NextChatMessage()
    {
        TextField.GetComponent<TextMeshProUGUI>().text += textList[currentMessage] + Environment.NewLine;
        currentMessage++;
        if(currentMessage >= 18)
        {
            EndCrashScene();
        }
    }
    void EndCrashScene()
    {
        TextField.GetComponent<TextMeshProUGUI>().text += textList[18] + Environment.NewLine;
        TextField.GetComponent<TextMeshProUGUI>().text += textList[19] + Environment.NewLine;
        TextField.GetComponent<TextMeshProUGUI>().text += textList[20] + Environment.NewLine;
        isChatActive = false;
        Invoke("LoadNextScene", 4f);
    }

    void LoadNextScene()
    {
        Debug.Log("next scene loading");
    }

}
