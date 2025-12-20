using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BubbleUI : MonoBehaviour
{
    public TextMeshProUGUI dialogue;
    public GameObject dialogueBubble;

    private void Start()
    {
        DialogueManager.instance.SetBaloonUI(this);
    }

    public void ActiveBuloonUI(string dialogueLine)
    {
        if (dialogueBubble != null)
        {
            dialogueBubble.SetActive(true);
            dialogue.text = dialogueLine;
        }
    }

    private void DeactiveBubble()
    {
        dialogueBubble.SetActive(false);
    }

    private void OnEnable()
    {
        DialogueManager.OnDialogueFinished += DeactiveBubble;
    }

    private void OnDisable()
    {
        DialogueManager.OnDialogueFinished -= DeactiveBubble;
    }
}
