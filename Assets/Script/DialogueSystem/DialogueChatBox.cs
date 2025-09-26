using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueChatBox : MonoBehaviour
{
    public void ShowDialogueChatBox(DialogueSO.DialogueLines dialogue)
    {
        Debug.Log($"{dialogue.speakerName} : {dialogue.dialogueTEXT}");
    }
}
