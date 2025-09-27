using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GenerateChoiceButton : MonoBehaviour
{
    [SerializeField] private GameObject choiceBoxPrefabs;
    [SerializeField] private Transform choiceContainer;

    [SerializeField] private DialogueChatBox _dialogueChatBox;

    public void OnGenerateChoiceBox(DialogueSO.DialogueLines dailogue)
    {
        // Remove any previous buttons
        ResetGenerateChoiceBox();

        foreach (var choice in dailogue.choices)
        {
            GameObject newChoiceBox = Instantiate(choiceBoxPrefabs, choiceContainer);
            ChoiceButton choiceButton = newChoiceBox.GetComponent<ChoiceButton>();

            choiceButton.SetChoiceButton(choice.choiceText, () => _dialogueChatBox.OnPlayerChoose(choice));
        }
    }

    public void ResetGenerateChoiceBox()
    {
        foreach (Transform child in choiceContainer)
            Destroy(child.gameObject);
    }
}
