using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;
 
    [Header("Status & config Dialogue")]
    [SerializeField] private bool isActive;
    [SerializeField] private int totalLines;
    [SerializeField] private DialogueSO currDialogue;

    [SerializeField] private int _currentIndexDialogue;

    [Header("Refencee")]
    [SerializeField] private DialogueLineChecker _dialogueLineChecker;
    [SerializeField] private DialogueChatBox _dialogueChatBox;
    [SerializeField] private DialogueBubble _dialogueBubble;

    public static event System.Action OnDialogueFinished;

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
        if (isActive && Input.GetKeyDown(KeyCode.Space))
        {
            HandleDialogueLine();
        }
    }

    public void StartDialogue()
    {
        if (currDialogue == null)
        {
            Debug.Log("There are no dialogue");
            return;
        }

        Debug.Log("Get Called");

        HandleDialogueLine();
        isActive = true;
    }

    public void ChangeCurrentDialogue(DialogueSO dialogue)
    {
        //Debug.Log($"dialogue name {dialogue.name}");
        currDialogue = dialogue;
        isActive = false;
        totalLines = currDialogue.lines.Length;
        _currentIndexDialogue = 0;

        if (DialogueSO.DialogueType.ChatBox == dialogue.lines[_currentIndexDialogue].dialogueType)
        {
            SetDialogueData(dialogue);
        }
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

    public void SetBaloonUI(BubbleUI ballonUI)
    {
        _dialogueBubble.SetBubbleUI(ballonUI);
    }

    public void SetMassageArea(Transform massageArea)
    {
        _dialogueChatBox.SetMassageArea(massageArea);
        _dialogueLineChecker.SetConatinerChatBox(massageArea);
    }

    public void SetMassageInputArea(Transform massageInputArea)
    {
        _dialogueChatBox.SetInputMassageArea(massageInputArea);
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
                
                _dialogueBubble.ShowLine(currentLine);
                if (currentLine.SoundFXName != null)
                {
                    string soundFX = currentLine.SoundFXName;

                    if (string.IsNullOrEmpty(soundFX))
                        return;

                    SoundManager.instance.PlaySoundFXOneClip(soundFX);
                }

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
        isActive = false;
        totalLines = 0;
        OnDialogueFinished?.Invoke();
    }

    public bool isDialogueActive() => isActive;
}
