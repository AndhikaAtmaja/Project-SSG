using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(menuName = "Dialogue")]
public class DialogueSO : ScriptableObject
{
    public enum DialogueType
    {
        ChatBox,
        BubbleChat,
        DialogueBox
    }

    [System.Serializable]
    public struct DialogueLines
    {
        public string speakerName;
        public DialogueType dialogueType;
        [TextArea(5, 10)] public string dialogueLine;
        public Sprite imageChar;

        public bool hasChoice;
        public ChoiceData[] choices;

        public bool triggerCutscene;
        public string cutsceneID;
    }

    [System.Serializable]
    public struct ChoiceData
    {
        public string choiceText;
        public DialogueSO nextDialogue;
    }

    public DialogueLines[] lines;
    public bool isDialogueDone;
}
