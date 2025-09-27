using System.Collections.Generic;
using UnityEngine;

public class GenerateLine : MonoBehaviour
{
    [Header("Type Writter Effects")]
    [SerializeField] private bool isWritting;
    public float defaultSpeedType;
    public float maxSpeedType;
    [SerializeField] private float _currSpeedType;

    [SerializeField] private DialogueChatBox chatBox;

    public void OnGenerateLine(DialogueSO.DialogueLines dialogue)
    {
        _currSpeedType = defaultSpeedType;

    }

    public bool GetisWritting()
    {
        return isWritting;
    }
}
