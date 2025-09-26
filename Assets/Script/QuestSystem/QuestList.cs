using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class QuestList : MonoBehaviour
{
    [SerializeField] private List<QuestSO> listOfQuests = new List<QuestSO>();
    [SerializeField] private int currQuestID;

    public UnityEvent UpdateQuestList;

    private void Start()
    {
        CheckListQuest();
    }

    private void CheckListQuest()
    {
        if (listOfQuests.Count == 0)
        {
            Debug.LogWarning($"there are no list of quest at QuestManager");
            return;
        }

        // Skip completed quests
        while (currQuestID < listOfQuests.Count && listOfQuests[currQuestID].isDone)
        {
            currQuestID++;
        }

        if (currQuestID >= listOfQuests.Count)
        {
            Debug.Log("All quests are done!");
        }
        else
        {
            Debug.Log($"Quest {currQuestID} : {listOfQuests[currQuestID].name}");
        }

        UpdateQuestList?.Invoke();
    }

    public void OnCheckQuest(bool isDone)
    {
        Debug.Log("Get call!");
        if (!listOfQuests[currQuestID].isDone)
        {
            listOfQuests[currQuestID].isDone = isDone;
            CheckListQuest();
        }
    }

    public string GetCurrQuestID()
    {
        if (currQuestID < 0 || currQuestID >= listOfQuests.Count)
        {
            return string.Empty;
        }
            

        return listOfQuests[currQuestID].questID;
    }
}
