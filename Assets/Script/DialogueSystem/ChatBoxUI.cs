using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChatBoxUI : MonoBehaviour
{
    [SerializeField] private Image profile;
    [SerializeField] private TextMeshProUGUI messageText;

    public void SetChatBox(string message)
    {
       messageText.text = message;
    }

    public string GetMessageText()
    {
        return messageText.text;
    }
}
