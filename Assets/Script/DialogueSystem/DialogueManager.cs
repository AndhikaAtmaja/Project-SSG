using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;
 
    [Header("Status & config Dialogue")]
    [SerializeField] private bool isDialogueActive;
    [SerializeField] private int totalLines;
    [SerializeField] private DialogueSO currDialogue;

    [SerializeField] private int _currentIndexDialogue;

    [Header("Refencee")]
    [SerializeField] private DialogueLineChecker _dialogueLineChecker;
    [SerializeField] private DialogueChatBox _dialogueChatBox;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    private void Update()
    {
        if (isDialogueActive && Input.GetKeyDown(KeyCode.Space))
        {
            HandleDialogueLine();
        }
    }

    public void StartDialogueChatBox()
    {
        if (currDialogue == null)
        {
            Debug.Log("There are no dialogue");
            return;
        }

        HandleDialogueLine();
        isDialogueActive = true;
    }

    public void ChangeCurrentDialogue(DialogueSO dialogue)
    {
        currDialogue = dialogue;
        isDialogueActive = false;
        totalLines = currDialogue.lines.Length;
        _currentIndexDialogue = 0;

        SetDialogueData(dialogue);
    }

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

        _currentIndexDialogue = resumeIndex;
    }

    public void NextLine()
    {
        // Move to next line
        _currentIndexDialogue++;
    }

    public void HandleDialogueLine()
    {
        if (currDialogue == null) return;

        if (_currentIndexDialogue >= currDialogue.lines.Length)
        {
            EndDialogue();
            return;
        }

        DialogueSO.DialogueLines currentLine = currDialogue.lines[_currentIndexDialogue];

        switch (currentLine.dialogueType)
        {
            case DialogueSO.DialogueType.ChatBox:
                _dialogueChatBox.ShowLine(currentLine);
                break;

            case DialogueSO.DialogueType.BubbleChat:
                break;

            case DialogueSO.DialogueType.DialogueBox:
                break;

            default:
                Debug.LogWarning($"there are no dialogue type with name : {currDialogue.lines[_currentIndexDialogue].dialogueType.ToString()}!");
                break;
        }
    }

    public void EndDialogue()
    {
        Debug.Log($"Dialogue '{currDialogue.name}' completed!");
        currDialogue.isDialogueDone= true;
        isDialogueActive = false;
        totalLines = 0;
        StoryManager.instance.CheckChapter();
    }

    public bool GetsDialogueActive() => isDialogueActive;
}
