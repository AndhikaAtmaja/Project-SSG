using System.Collections.Generic;
using UnityEngine;

public enum QuestObjectiveType
{
    OpenChapterBook,
    OpenCamera,
    TakePhoto,
    OpenSosialMedia,
    OpenMessage,
    ChangeScene,
    ClickChapter
}

[System.Serializable]
public class QuestObjective
{
    public string description;
    public QuestObjectiveType type;
    public string targetSceneName;

    public bool isCompleted;
}

[CreateAssetMenu(menuName = "Quest")]
public class QuestSO : ScriptableObject
{
    public string questID;
    public string questName; 
    public Sprite questImage;
    public List<QuestObjective> objectives = new List<QuestObjective>();
    public bool IsCompleted;
}
