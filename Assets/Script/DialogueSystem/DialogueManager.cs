using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;
 
    [Header("Status & config Dialogue")]
    [SerializeField] private bool isDialogueActive;
    [SerializeField] private GenerateLine _generateLine;

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

    public void StartDialogueChatBox(DialogueSO dialogueData)
    {
        _generateLine.SetDialogueData(dialogueData);
    }
}
