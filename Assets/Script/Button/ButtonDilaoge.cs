using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonDilaoge : MonoBehaviour
{
    public void OnButtonClick()
    {
        if (!DialogueManager.instance.isActive())
        {
            DialogueManager.instance.StartDialogue();
        }
        else
        {
            DialogueManager.instance.EndDialogue();
        }
    }
}
