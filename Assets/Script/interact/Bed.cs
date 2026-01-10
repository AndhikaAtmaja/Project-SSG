using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bed : Interact, IInteractable
{
    public string questID;
    public QuestSO quest;

    private void Start()
    {
        quest = QuestManager.instance.FindQuestByID(questID);
    }

    public void interact()
    {
        if (quest != null)
        {
            QuestManager.instance.GetCheckQuest(quest.questID, true);
        }
        Debug.Log($"there to use {gameObject.name}");
    }
}
