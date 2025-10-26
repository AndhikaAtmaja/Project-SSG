using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonDilaoge : MonoBehaviour
{
    public void OnButtonClick()
    {
        if (!DialogueManager.instance.GetsDialogueActive())
        {
            DialogueManager.instance.StartDialogueChatBox();
        }
        else
        {
            DialogueManager.instance.EndDialogue();
        }
    }
}
