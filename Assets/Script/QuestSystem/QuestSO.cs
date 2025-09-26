using UnityEngine;

[CreateAssetMenu(menuName = "Quest")]
public class QuestSO : ScriptableObject
{
    public string questID;
    public Sprite questImage;
    public bool isDone;

    public bool GetisDone()
    {
        return isDone;
    }
}
