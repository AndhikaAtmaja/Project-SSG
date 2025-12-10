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
        ResetAllQuests();
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

        // Skip completed questChapter
        while (currQuestID < listOfQuests.Count && listOfQuests[currQuestID].IsCompleted)
        {
            currQuestID++;
        }

        if (currQuestID >= listOfQuests.Count)
        {
            Debug.Log("All questChapter are done!");
            UpdateQuestList?.Invoke();
            return;
        }

        //Debug.Log($"Quest {currQuestID} : {listOfQuests[currQuestID].name}");
        UpdateQuestList?.Invoke();
    }

    public void OnCheckQuest(string questID, bool isDone)
    {
        if (listOfQuests == null || currQuestID < 0 || currQuestID >= listOfQuests.Count)
        {
            Debug.LogWarning("No valid current quest to update.");
            return;
        }

        if (questID == listOfQuests[currQuestID].questID)
        {
            listOfQuests[currQuestID].IsCompleted = isDone;
        }
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
        listOfQuests.Clear();

        for (int i = 0; i < listQuests.Count; i++)
        {
            listOfQuests.Add(listQuests[i]);
        }

        ResetAllQuests();
        CheckListQuest();
    }

    private void ResetAllQuests()
    {
        foreach (var quest in listOfQuests)
        {
            quest.IsCompleted = false;
            foreach (var objective in quest.objectives)
            {
                objective.isCompleted = false;
            }
        }
    }
}
