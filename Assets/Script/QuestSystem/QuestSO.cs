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
    ClickChapter,
    ClickAdd,
    ClickAnyPicture,
    ClickUpload
}

public enum InteractTargetType
{
    none,
    bed,
    bathroom,
    bedroom,
    outside,
    makeup,
    wastafel
}

[System.Serializable]
public class QuestObjective
{
    public string description;
    public QuestObjectiveType type;
    public string targetSceneName;

    public bool isCompleted;
}

[System.Serializable]
public class QuestHighlightData
{
    public InteractTargetType target;
}

[CreateAssetMenu(menuName = "Quest")]
public class QuestSO : ScriptableObject
{
    public string questID;
    public string questName; 
    public Sprite questImage;
    public List<QuestObjective> objectives = new List<QuestObjective>();
    public QuestHighlightData interactType;
    public bool IsCompleted;
}
