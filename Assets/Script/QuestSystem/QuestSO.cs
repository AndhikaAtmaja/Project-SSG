using UnityEngine;

[CreateAssetMenu(menuName = "Quest")]
public class QuestSO : ScriptableObject
{
    public string questID;
    public Sprite questImage;
    public string nextScene;
    public bool isDone;

    public bool GetisDone()
    {
        return isDone;
    }
}
