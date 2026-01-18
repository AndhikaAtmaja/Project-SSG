using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UploadButton : MonoBehaviour
{
    public QuestSO quest;
    public string questID;

    private void Start()
    {
        if (quest == null)
            quest = QuestManager.instance.FindQuestByID(questID);
    }

    public void CompletedQuest()
    {
        QuestManager.instance.GetCheckQuest(quest.questID, true);
    }
}
