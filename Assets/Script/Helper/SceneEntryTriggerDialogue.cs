using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneEntryTriggerDialogue : MonoBehaviour
{
    private void Start()
    {
        Debug.Log("Get Called");
        StartCoroutine(TryToAutoTriggerDialogue());
    }

    private IEnumerator TryToAutoTriggerDialogue()
    {
        Debug.Log("Get Called");
        StoryStep step = StoryManager.instance.currentStep;
        if (step == null) yield break;

        if (!step.autoStartDialogueAfterScene)
        {
            yield break;
        }

        if(step.dialogues == null || step.dialogues.Count == 0)
            yield break;

        DialogueManager.instance.StartDialogue();
    }
}
