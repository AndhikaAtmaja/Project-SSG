using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonDilaoge : MonoBehaviour
{
    public static event Action<string> OnClickButton;
    public void OnButtonClick()
    {
        OnClickButton?.Invoke(gameObject.name);
        if (!DialogueManager.instance.isDialogueActive())
        {
            DialogueManager.instance.StartDialogue();
        }
        else
        {
            DialogueManager.instance.EndDialogue();
        }
    }
}
