using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueBubble : Dialogue
{
    public override void ShowLine(DialogueSO.DialogueLines line)
    {
        Debug.Log($"{line.speakerName} : {line.dialogueLine}");
        DialogueManager.instance.NextLine();
    }
}
