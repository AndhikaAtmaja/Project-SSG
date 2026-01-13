using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bed : Interact, IInteractable
{
    public string questID;
    public QuestSO currentQuest;

    private void Start()
    {
        currentQuest = QuestManager.instance.FindQuestByID(questID);
    }

    private void SetQuest(QuestSO quest)
    {
        string prefix = quest.questID.Split('-')[0];

        if (prefix == questID)
        {
            currentQuest = quest;
        }
    }

    public void interact()
    {
        if (currentQuest != null)
        {
            QuestManager.instance.GetCheckQuest(currentQuest.questID, true);
        }
        Debug.Log($"there to use {gameObject.name}");
    }

    private void OnEnable()
    {
        QuestManager.instance.SetQuestEvent += SetQuest;
    }

    private void OnDisable()
    {
        QuestManager.instance.SetQuestEvent -= SetQuest;
    }
}
