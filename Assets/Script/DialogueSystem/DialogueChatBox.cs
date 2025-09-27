using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueChatBox : MonoBehaviour
{
    [SerializeField] private GenerateChatBox _generateChatBox;
    [SerializeField] private GenerateLine _generateLine;
    [SerializeField] private GenerateChoiceButton _generateChoiceButton;
    private Queue<DialogueSO.DialogueLines> dialogues;

    public void SetDialogueData(DialogueSO dialogue)
    {
        if (dialogues == null)
            dialogues = new Queue<DialogueSO.DialogueLines>();

        dialogues.Clear();

        foreach (var line in dialogue.lines)
        {
            dialogues.Enqueue(line);
        }

        OnChatDialogue();
    }

    public void OnChatDialogue()
    {
        if (dialogues.Count <= 0)
            return;

        var dialogue = dialogues.Dequeue();
        _generateLine.OnGenerateLine(dialogue);

        if (dialogue.choices.Length > 0)
        {
            _generateChoiceButton.OnGenerateChoiceBox(dialogue);
        }
    }

    public void OnPlayerChoose(DialogueSO.ChoiceData choice)
    {
        if (choice.nextDialogue != null)
            SetDialogueData(choice.nextDialogue);
    }

    public void ShowDialogueChatBox(DialogueSO.DialogueLines dialogue)
    {
        Debug.Log($"{dialogue.speakerName} : {dialogue.dialogueLine}");
        _generateChatBox.OnGenerateChatBox(dialogue.speakerName, dialogue.dialogueLine);
    }
}
