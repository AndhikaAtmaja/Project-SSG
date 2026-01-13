using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueBubble : Dialogue
{
    [SerializeField] private BubbleUI _bubbleUI;

    public void SetBubbleUI(BubbleUI baloonUI)
    {
       if (_bubbleUI == null)
            _bubbleUI = baloonUI;
    }

    public override void ShowPersonalDialogueChat(DialogueSO.DialogueLines line)
    {
        Debug.Log($"{line.speakerName} : {line.dialogueLine}");
        _bubbleUI.ActiveBuloonUI(line.dialogueLine);
        DialogueManager.instance.NextLine();
    }
}
