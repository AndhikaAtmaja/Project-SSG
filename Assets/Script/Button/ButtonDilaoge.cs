using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonDilaoge : MonoBehaviour
{
    public void OnButtonClick()
    {
        DialogueManager.instance.StartDialogueChatBox();
    }
}
