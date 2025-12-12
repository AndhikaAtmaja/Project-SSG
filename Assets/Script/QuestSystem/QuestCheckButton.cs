using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestCheckButton : MonoBehaviour
{
    public QuestSO quest;

    public void CompletedQuest()
    {
        QuestManager.instance.GetCheckQuest(quest.questID, true);
    }
}
