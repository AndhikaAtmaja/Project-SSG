using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueChatBox : MonoBehaviour
{
    public TextMeshProUGUI contactName;
    public TextMeshProUGUI message;

    [SerializeField] private GenerateChatBox _generateChatBox;

    public void ShowDialogueChatBox(DialogueSO.DialogueLines dialogue)
    {
        Debug.Log($"{dialogue.speakerName} : {dialogue.dialogueTEXT}");
        _generateChatBox.OnGenerateChatBox(dialogue.speakerName);
    }

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        
    }

    private void CheckChatBox()
    {

    }
}
