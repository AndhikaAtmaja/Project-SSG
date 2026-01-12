using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoor : Interact, IInteractable
{
    public string questID;
    public QuestSO quest;
    public string animatioName;

    private void Start()
    {
        quest = QuestManager.instance.FindQuestByID(questID);
    }

    public void interact()
    {
        Debug.Log($"there to use {gameObject.name}");

        if (quest != null)
        {
            if (!string.IsNullOrEmpty(animatioName))
                AnimationManager.instance.PlayAnimation(animatioName);

            QuestManager.instance.GetCheckQuest(quest.questID, true);
        }
    }
}
