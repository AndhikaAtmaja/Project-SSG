using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestDataBase : MonoBehaviour
{
    [SerializeField] private List<QuestSO> questdData;

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
