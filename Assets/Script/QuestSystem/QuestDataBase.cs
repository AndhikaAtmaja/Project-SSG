using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestDataBase : MonoBehaviour
{
    [SerializeField] private List<QuestSO> questdData;

    public void FillWithNewQuest(List<QuestSO> listQuests)
    {
        questdData.Clear();

        for (int i = 0; i < listQuests.Count; i++)
        {
            questdData.Add(listQuests[i]);
        }
    }

    public QuestSO FindQuestData(string questID)
    {
        for (int i = 0; i < questdData.Count; i++)
        {
            if (questdData[i].questID == questID)
            {
                return questdData[i];
            } 
        }
        return null;
    }

}
