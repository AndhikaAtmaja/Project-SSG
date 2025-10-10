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
    public DialogueSO currDialogue;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        StartDialogueChatBox();
    }

    private void Update()
    {
        if (isDialogueActive && Input.GetKeyDown(KeyCode.Space))
            _dialogueChatBox.OnChatDialogue();
    }

    public void StartDialogueChatBox()
    {
        _dialogueChatBox.SetDialogueData(currDialogue);
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
