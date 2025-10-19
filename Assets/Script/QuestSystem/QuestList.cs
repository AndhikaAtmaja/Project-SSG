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

        currQuestID = Mathf.Clamp(currQuestID, 0, listOfQuests.Count - 1);
        //currQuestID = 0;

        // Skip completed quests
        while (currQuestID < listOfQuests.Count && listOfQuests[currQuestID].isDone)
        {
            currQuestID++;
        }

        if (currQuestID >= listOfQuests.Count)
        {
            Debug.Log("All quests are done!");
            UpdateQuestList?.Invoke();
            return;
        }

        //Debug.Log($"Quest {currQuestID} : {listOfQuests[currQuestID].name}");
        UpdateQuestList?.Invoke();
    }

    public void OnCheckQuest(bool isDone)
    {
        if (listOfQuests == null || currQuestID < 0 || currQuestID >= listOfQuests.Count)
        {
            Debug.LogWarning("No valid current quest to update.");
            return;
        }

        listOfQuests[currQuestID].isDone = isDone;
        CheckListQuest();
    }

    public QuestSO GetCurrentQuest()
    {
        if (currQuestID < 0 || currQuestID >= listOfQuests.Count)
        {
            return null;
        }

        return listOfQuests[currQuestID];
    }

    public void SetQuestDataByChapter(List<QuestSO> listQuests)
    {
        ClearCurrentQuestList();

        for(int i = 0; i < listQuests.Count; i++)
        {
            listOfQuests.Add(listQuests[i]);
        }

        CheckListQuest();
    }

    private void ClearCurrentQuestList()
    {
        listOfQuests.Clear();
    }
}
