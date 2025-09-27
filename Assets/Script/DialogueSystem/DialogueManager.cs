using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;
 
    [Header("Status & config Dialogue")]
    [SerializeField] private bool isDialogueActive;
    [SerializeField] private DialogueChatBox _dialogueChatBox;

    [Header("Test")]
    public DialogueSO testDialogue;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        StartDialogueChatBox(testDialogue);
    }

    private void Update()
    {
        if (isDialogueActive && Input.GetKeyDown(KeyCode.Space))
            _dialogueChatBox.OnChatDialogue();
    }

    public void StartDialogueChatBox(DialogueSO dialogueData)
    {
        _dialogueChatBox.SetDialogueData(dialogueData);
        isDialogueActive = true;
    }

    public void EndDialogue()
    {
        isDialogueActive = false;
    }

    public bool GetsDialogueActive()
    {
        return isDialogueActive;
    }
}
