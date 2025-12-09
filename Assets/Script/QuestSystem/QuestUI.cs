using UnityEngine;
using UnityEngine.UI;

public class QuestUI : MonoBehaviour
{
    [SerializeField] private GameObject questBackGround;
    [SerializeField] private Image questImage;

    //data base
    [SerializeField] private QuestList _questList;
    [SerializeField] private QuestDataBase _questDB;

    private void Start()
    {
        _questList = GameObject.FindGameObjectWithTag("QuestList").GetComponent<QuestList>();
        _questList.UpdateQuestList.AddListener(UpdateQuestUI);

        _questDB = GameObject.FindGameObjectWithTag("QuestDB").GetComponent<QuestDataBase>();
    }

    public void UpdateQuestUI()
    {
        if (questBackGround == null)
        {
            Debug.LogWarning("QuestUI: questBackGround not assigned!");
            return;
        }

        QuestSO currentQuest = _questList.GetCurrentQuest();

        // If there are no more questChapter, hide everything
        if (currentQuest == null)
        {
            questBackGround.SetActive(false);
            questImage.sprite = null;
            Debug.Log("QuestUI: All questChapter completed, hiding quest UI.");
            return;
        }

        QuestSO quest = _questDB.FindQuestData(_questList.GetCurrentQuest().questID);

        if (quest != null)
        {
            if (quest.IsCompleted)
            {
                questBackGround.SetActive(false);
                questImage.sprite = null;
                Debug.Log($"QuestUI: Quest '{quest.questName}' is done, hiding UI.");
            }
            else
            {
                // Show the current quest info
                questBackGround.SetActive(true);
                questImage.sprite = quest.questImage;
            }
        }
        else
        {
            // If quest data not found in DB, hide UI
            questBackGround.SetActive(false);
            questImage.sprite = null;
            Debug.LogWarning("QuestUI: Quest data not found in database!");
        }
    }
}
