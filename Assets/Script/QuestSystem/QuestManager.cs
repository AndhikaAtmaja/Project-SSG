using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public static QuestManager instance;
    [SerializeField] private QuestList _questList;
    [SerializeField] private QuestDataBase _questData;
    [SerializeField] private GameObject questBox;

    [Header("Events")]
    public InteractHighlightEventSO interactHighlight;
    public ClearHighlightEventSO clearHighlight;

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
       HighlightArea();
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
        _questData.FillWithNewQuest(quests);
    }

    public QuestSO FindQuestByID(string questID)
    {
        return _questList.SearchQuestByID(questID);
    }

    public void ShowQuets()
    {
        _questList.StartQuest();
    }

    public void HighlightArea()
    {
        if (_questList.GetCurrentQuest() != null)
            interactHighlight.RaiseHighlight(_questList.GetCurrentQuest().interactType.target, _questList.GetCurrentQuest().IsCompleted);
    }

    public void ClearHighlight()
    {
        clearHighlight.RaiseClearHighlight();
    }

    public QuestSO GetCurrentQuest()
    {
        return _questList.GetCurrentQuest();
    }
}
