using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueLineChecker : MonoBehaviour
{
    [SerializeField] private Transform areaChat;

    public void SetConatinerChatBox(Transform massageArea)
    {
        areaChat = massageArea;
    }

    public List<string> GetExistingDialogueLines()
    {
        List<string> existingLines = new List<string>();

        foreach (Transform child in areaChat)
        {
            ChatBoxUI chatBoxUI = child.GetComponent<ChatBoxUI>();
            if (chatBoxUI != null)
            {
                existingLines.Add(chatBoxUI.GetMessageText());
            }
        }

        return existingLines;
    }
}
