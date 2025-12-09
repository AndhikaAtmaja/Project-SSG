using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public static QuestManager instance;
    [SerializeField] private QuestList _questList;
    [SerializeField] private GameObject questBox;
    [SerializeField] private QuestSO currQuest;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        _questList = GameObject.FindGameObjectWithTag("QuestList").GetComponent<QuestList>();
    }

    public void GetCheckQuest(string questID, bool isDone)
    {
        _questList.OnCheckQuest(questID,isDone);
    }

    public void FillQuest(List<QuestSO> quests)
    {
        if (_questList == null)
        {
            Debug.LogWarning("Not Assign the QuestList");
            return;
        }

        _questList.SetQuestDataByChapter(quests);
    }
}
