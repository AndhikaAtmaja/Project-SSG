using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestChecker : MonoBehaviour
{
    [SerializeField] private QuestList questList;

    private void CheckObjectivePhone(QuestObjectiveType type)
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

    private void CheckObjectiveChangeScene(QuestObjectiveType type, string nameScene)
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
            }
        }

        // Check if all objectives in this quest are done
        if (updated && currentQuest.objectives.TrueForAll(o => o.isCompleted))
        {
            currentQuest.IsCompleted = true;
            Debug.Log($"Quest '{currentQuest.questName}' completed!");
            questList.OnCheckQuest(currentQuest.questID, currentQuest.IsCompleted);
        }
    }

    private void OnEnable()
    {
        PhoneApplication.OnApplicationOpenned += HandleAppOpened;
        ChangeScene.OnChangeScene += HandleChangeScene;
    }
    private void OnDisable()
    {
        PhoneApplication.OnApplicationOpenned -= HandleAppOpened;
        ChangeScene.OnChangeScene -= HandleChangeScene;
    }
    private void HandleAppOpened(string appName)
    {
        switch (appName.ToLower())
        {
            case "camera":
                CheckObjectivePhone(QuestObjectiveType.OpenCamera);
                break;

            case "chapterbook":
                CheckObjectivePhone(QuestObjectiveType.OpenChapterBook);
                break;

            case "massage":
                CheckObjectivePhone(QuestObjectiveType.OpenMessage); 
                break;

            case "sosialmedia":
                CheckObjectivePhone(QuestObjectiveType.OpenSosialMedia); 
                break;
        }
    }

    private void HandleChangeScene(string nameScene)
    {
        //Trim name if nameScene
        string name = nameScene.Split('-')[0].ToLower();

        Debug.Log($"Scene name before trim : {nameScene}" +
                  $"Scene name after trim  : {name}");

        switch (name.ToLower())
        {
            case "bedroom":
                CheckObjectiveChangeScene(QuestObjectiveType.ChangeScene, name);
                break;


            default:
                break;
        }
    }
}
