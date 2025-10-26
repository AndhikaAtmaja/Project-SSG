using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;
 
    [Header("Status & config Dialogue")]
    [SerializeField] private bool isDialogueActive;
    [SerializeField] private DialogueChatBox _dialogueChatBox;
    [SerializeField] private int totalLines;

    [SerializeField] private DialogueSO currDialogue;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    private void Update()
    {
        if (isDialogueActive && Input.GetKeyDown(KeyCode.Space))
        {
            HandleDailogueLine();
        }
    }

    public void StartDialogueChatBox()
    {
        if (currDialogue == null)
        {
            Debug.Log("There are no dialogue");
            return;
        }

        _dialogueChatBox.SetDialogueData(currDialogue);
        isDialogueActive = true;
    }

    public void ChangeCurrentDialogue(DialogueSO dialogue)
    {
        currDialogue = dialogue;
        isDialogueActive = false;
        totalLines = currDialogue.lines.Length;
    }

    public void HandleDailogueLine()
    {
        if (currDialogue == null) return;

        _dialogueChatBox.OnChatDialogue();

        if (_dialogueChatBox.GetCurrentIndex() >= currDialogue.lines.Length)
        {
            currDialogue.isDialogueDone = true;
            EndDialogue();
        }
    }

    public void EndDialogue()
    {
        Debug.Log($"Dialogue '{currDialogue.name}' completed!");
        isDialogueActive = false;
        totalLines = 0;
        StoryManager.instance.CheckChapter();
    }

    public DialogueSO GetCurrentDialoge()
    {
        return currDialogue;
    }

    public bool GetsDialogueActive() => isDialogueActive;
}
