using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueChatBox : Dialogue
{
    [SerializeField] private GenerateChatBox _generateChatBox;
    [SerializeField] private GenerateLine _generateLine;
    [SerializeField] private GenerateChoiceButton _generateChoiceButton;
    private bool waitingForChoice = false;

    public override void ShowLine(DialogueSO.DialogueLines line)
    {
        if (waitingForChoice) 
            return;          // don't skip a choice
        
        _generateLine.OnGenerateLine(line);
        _generateChatBox.OnGenerateChatBox(line.speakerName, line.dialogueLine);

        if (line.choices.Length > 0)
        {
            waitingForChoice = true;
            _generateChoiceButton.OnGenerateChoiceBox(line);
            // Do NOT auto-move to next line; wait for player to click a button
        }
        else
        {
            waitingForChoice = false;
            _generateChoiceButton.ResetGenerateChoiceBox();
            DialogueManager.instance.NextLine(); // Continue automatically
        }
    }

    public override void OnPlayerChoose(DialogueSO.ChoiceData choice)
    {
        waitingForChoice = false;
        if (choice.nextDialogue != null)
        {
            DialogueManager.instance.ChangeCurrentDialogue(choice.nextDialogue);
            DialogueManager.instance.StartDialogue();
        }
        else
        {
            DialogueManager.instance.NextLine();
        }
    }
}
