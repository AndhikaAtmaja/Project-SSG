using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;
 
    [Header("Status & config Dialogue")]
    [SerializeField] private bool isDialogueActive;
    [SerializeField] private DialogueChatBox _dialogueChatBox;

    [SerializeField] public DialogueSO currDialogue { private get; set; }

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
            _dialogueChatBox.OnChatDialogue();
    }

    public void StartDialogueChatBox()
    {
        if (currDialogue == null)
        {
            Debug.Log("There are no dialogue");
            return;
        }

        if (currDialogue != null)
        {
            int totalDialoge;
            totalDialoge = currDialogue.lines.Length;
            Debug.Log($"{currDialogue.name} is have {totalDialoge}");
        }

        _dialogueChatBox.SetDialogueData(currDialogue);
        isDialogueActive = true;
    }

    public void EndDialogue()
    {
        isDialogueActive = false;
    }

    public DialogueSO GetCurrentDialoge()
    {
        return currDialogue;
    }

    public bool GetsDialogueActive()
    {
        return isDialogueActive;
    }
}
