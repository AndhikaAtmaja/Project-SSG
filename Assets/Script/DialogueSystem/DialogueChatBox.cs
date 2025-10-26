using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueChatBox : MonoBehaviour
{
    [SerializeField] private GenerateChatBox _generateChatBox;
    [SerializeField] private GenerateLine _generateLine;
    [SerializeField] private GenerateChoiceButton _generateChoiceButton;
    [SerializeField] private DialogueLineChecker _dialogueLineChecker;

    private DialogueSO currentDialogue;
    [SerializeField] private int currentIndex = 0;
    private bool waitingForChoice = false;

    public void SetDialogueData(DialogueSO dialogue)
    {
        List<string> existingLines = _dialogueLineChecker.GetExistingDialogueLines();

        int resumeIndex = 0;
        for (int i = 0; i < dialogue.lines.Length; i++)
        {
            if (existingLines.Contains(dialogue.lines[i].dialogueLine))
                resumeIndex++;
            else
                break;
        }

        currentDialogue = dialogue;
        currentIndex = resumeIndex;

        OnChatDialogue();
    }

    public void OnChatDialogue()
    {
        if (waitingForChoice) 
            return;          // don't skip a choice

        if (currentDialogue == null) 
            return ;

        if (currentIndex >= currentDialogue.lines.Length) 
            return;

        var line = currentDialogue.lines[currentIndex];
        
        _generateLine.OnGenerateLine(line);
        ShowChatBox();

        if (line.choices.Length > 0)
        {
            waitingForChoice = true;
            _generateChoiceButton.OnGenerateChoiceBox(line);
            currentIndex++;

        }
        else
        {
            _generateChoiceButton.ResetGenerateChoiceBox();
            currentIndex++;
        }
    }

    public void ShowChatBox()
    {
        _generateChatBox.OnGenerateChatBox(currentDialogue.lines[currentIndex].speakerName, currentDialogue.lines[currentIndex].dialogueLine);
    }

    public void OnPlayerChoose(DialogueSO.ChoiceData choice)
    {
        waitingForChoice = false;
        if (choice.nextDialogue != null)
        {
            SetDialogueData(choice.nextDialogue);
            DialogueManager.instance.ChangeCurrentDialogue(choice.nextDialogue);
            DialogueManager.instance.StartDialogueChatBox();
        }
        else
        {
            OnChatDialogue();
        }
    }

    public int GetCurrentIndex() => currentIndex;
    public bool EndDialogueLine() => waitingForChoice;
}
