using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue")]

public class DialogueSO : ScriptableObject
{
    [System.Serializable]
    public struct DialogueLines
    {
        public string speakerName;
        [TextArea(5, 10)] public string dialogueTEXT;
        public Sprite imageChar;

        public bool triggerCutscene;
        public string cutsceneID;
    }

    public DialogueLines[] lines;
}
