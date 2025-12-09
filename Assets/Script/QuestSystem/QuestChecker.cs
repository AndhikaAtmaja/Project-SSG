using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestChecker : MonoBehaviour
{
    [SerializeField] private QuestList questList;

    private void CheckObjective(QuestObjectiveType type)
    {
        if (questList == null)
        {
            Debug.LogWarning("QuestList not found!");
            return;
        }

        var currentQuest = questList.GetCurrentQuest();
        if (currentQuest == null)
        {
            Debug.Log("No active quest found.");
            return;
        }

        bool updated = false;
        foreach (var obj in currentQuest.objectives)
        {
            if (obj.type == type && !obj.isCompleted)
            {
                obj.isCompleted = true;
                updated = true;
                Debug.Log($"Objective '{obj.description}' completed!");
                StoryManager.instance.CheckChapter();
            }
        }

        // Check if all objectives in this quest are done
        if (updated && currentQuest.objectives.TrueForAll(o => o.isCompleted))
        {
            currentQuest.IsCompleted = true;
            Debug.Log($"Quest '{currentQuest.questName}' completed!");
            questList.OnCheckQuest(currentQuest.questID ,currentQuest.IsCompleted);
        }
    }

    private void OnEnable()
    {
        PhoneApplication.OnApplicationOpenned += HandleAppOpened;
    }
    private void OnDisable()
    {
        PhoneApplication.OnApplicationOpenned -= HandleAppOpened;
    }
    private void HandleAppOpened(string appName)
    {
        switch (appName.ToLower())
        {
            case "camera":
                CheckObjective(QuestObjectiveType.OpenCamera);
                break;

            case "chapterbook":
                CheckObjective(QuestObjectiveType.OpenChapterBook);
                break;

            case "massage":
                CheckObjective(QuestObjectiveType.OpenMessage); 
                break;

            case "sosialmedia":
                CheckObjective(QuestObjectiveType.OpenSosialMedia); 
                break;
        }
    }
}
