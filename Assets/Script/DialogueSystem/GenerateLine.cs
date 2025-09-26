using System.Collections.Generic;
using UnityEngine;

public class GenerateLine : MonoBehaviour
{
    [Header("Type Writter Effects")]
    public float defaultSpeedType;
    public float maxSpeedType;
    [SerializeField] private float _currSpeedType;

    private Queue<DialogueSO.DialogueLines> paragraphs;
    [SerializeField] private DialogueChatBox chatBox;

    private void Update()
    {
        if (DialogueManager.instance.GetsDialogueActive())
            OnGenerateLine();
    }

    public void SetDialogueData(DialogueSO dialogue)
    {
        if (paragraphs == null)
            paragraphs = new Queue<DialogueSO.DialogueLines>();

        paragraphs.Clear();

        foreach (var line in dialogue.lines)
        {
            paragraphs.Enqueue(line);
        }

        OnGenerateLine();
    }

    private void OnGenerateLine()
    {
        //check if paragrah is empty or not
        if (paragraphs.Count == 0)
        {
            DialogueManager.instance.EndDialogue();
            return;
        }

        _currSpeedType = defaultSpeedType;

        var line = paragraphs.Dequeue();

        chatBox.ShowDialogueChatBox(line);
    }
}
