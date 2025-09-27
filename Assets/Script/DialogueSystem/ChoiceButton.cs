using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class ChoiceButton : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI choiceTitle;
    private Button button;

    public void SetChoiceButton(string choice, Action onClick)
    {
        choiceTitle.text = choice;
        button = GetComponent<Button>();
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(() => onClick?.Invoke());
    }
}
