using System.Collections.Generic;
using UnityEngine;

public enum QuestObjectiveType
{
    TalkToNPC,
    OpenCamera,
    TakePhoto,
    EnterZone,
    CollectItem
}

[System.Serializable]
public class QuestObjective
{
    public string description;
    public QuestObjectiveType type;
    public bool isCompleted;
}

[CreateAssetMenu(menuName = "Quest")]
public class QuestSO : ScriptableObject
{
    public string questID;
    public string questName; 
    public Sprite questImage;
    public string nextScene;
    public List<QuestObjective> objectives = new List<QuestObjective>();
    public bool isDone;

    public bool GetisDone()
    {
        return isDone;
    }
}
