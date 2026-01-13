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
            Debug.Log("No active currentQuest found.");
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

        // Check if all objectives in this currentQuest are done
        if (updated && currentQuest.objectives.TrueForAll(o => o.isCompleted))
        {
            currentQuest.IsCompleted = true;
            Debug.Log($"Quest '{currentQuest.questName}' completed!");
            questList.OnCheckQuest(currentQuest.questID ,currentQuest.IsCompleted);
        }
    }

    private void CheckObjectiveChangeScene(string loadedSceneName)
    {
        if (questList == null)
        {
            Debug.LogWarning("QuestList not found!");
            return;
        }

        var currentQuest = questList.GetCurrentQuest();

        if (currentQuest == null)
        {
            Debug.Log("No active currentQuest found.");
            return;
        }

        bool updated = false;

      
        foreach (var obj in currentQuest.objectives)
        {
            Debug.Log($"Objective type: {obj.type}");
            Debug.Log($"Target scene: '{obj.targetSceneName}'");
            Debug.Log($"Loaded scene: '{loadedSceneName}'");

            if (obj.type != QuestObjectiveType.ChangeScene)
                continue;

            if (obj.isCompleted)
                continue;

            if (string.IsNullOrEmpty(obj.targetSceneName))
            {
                Debug.LogWarning("ChangeScene objective has EMPTY targetSceneName!");
                continue;
            }

            if (obj.targetSceneName.ToLower() == loadedSceneName.ToLower())
            {
                obj.isCompleted = true;
                updated = true;
                Debug.Log("ChangeScene objective MATCHED and completed");
            }
        }

        if (updated && currentQuest.objectives.TrueForAll(o => o.isCompleted))
        {
            currentQuest.IsCompleted = true;
            Debug.Log($"Quest '{currentQuest.questName}' completed!");
            questList.OnCheckQuest(currentQuest.questID, currentQuest.IsCompleted);
        }
    }

    private void CheckObjectiveClick(QuestObjectiveType type)
    {
        if (questList == null)
        {
            Debug.LogWarning("QuestList not found!");
            return;
        }

        var currentQuest = questList.GetCurrentQuest();
        if (currentQuest == null)
        {
            Debug.Log("No active currentQuest found.");
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

        // Check if all objectives in this currentQuest are done
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
        ButtonChapter.OnClickButton += HandleClikcButton;
        ButtonDilaoge.OnClickButton += HandleClikcButton;
        SceneManagement.OnSuccesChangeScene += HandleChangeScene;
    }
    private void OnDisable()
    {
        PhoneApplication.OnApplicationOpenned -= HandleAppOpened;
        ButtonChapter.OnClickButton -= HandleClikcButton;
        ButtonDilaoge.OnClickButton -= HandleClikcButton;
        SceneManagement.OnSuccesChangeScene -= HandleChangeScene;
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
                CheckObjectivePhone(QuestObjectiveType.OpenMessageApp); 
                break;

            case "pictgram":
                CheckObjectivePhone(QuestObjectiveType.OpenSosialMedia); 
                break;
        }
    }

    private void HandleClikcButton(string nameButton)
    {
        string name = nameButton.Split('-')[0].ToLower();

        switch (name)
        {
            case "chapter":
                CheckObjectiveClick(QuestObjectiveType.ClickChapter);
                break;

            case "massage":
                CheckObjectiveClick(QuestObjectiveType.OpenMessage);
                break;

            default:
                break;
        }
    }

    private void HandleChangeScene(string nameScene)
    {
        //Trim name if nameScene
        string name = nameScene.Split('-')[0].ToLower();

        /*Debug.Log(nameScene);
        Debug.Log(name);*/

        CheckObjectiveChangeScene(nameScene);
    }
}
