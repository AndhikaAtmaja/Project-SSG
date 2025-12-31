using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestUI : MonoBehaviour
{
    [SerializeField] private GameObject questBackGround;
    [SerializeField] private Image questImage;
    [SerializeField] private TextMeshProUGUI questDesc;

    //data base
    [SerializeField] private QuestList _questList;
    [SerializeField] private QuestDataBase _questDB;

    private void Start()
    {
        _questList = GameObject.FindGameObjectWithTag("QuestList").GetComponent<QuestList>();
    
        _questDB = GameObject.FindGameObjectWithTag("QuestDB").GetComponent<QuestDataBase>();

        _questList.UpdateQuestList.AddListener(UpdateQuestUI);
        QuestManager.instance.ShowQuets();
    }

    public void UpdateQuestUI()
    {
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
                //questBackGround.SetActive(false);
                questImage.sprite = null;
                Debug.Log($"QuestUI: Quest '{quest.questName}' is done, hiding UI.");
            }
            else
            {
                // Show the current quest info
                //questBackGround.SetActive(true);
                if (questImage != null)
                    questImage.sprite = quest.questImage;
                if (questDesc != null)
                    questDesc.text = quest.questName;
            }
        }
        else
        {
            // If quest data not found in DB, hide UI
            //questBackGround.SetActive(false);
            //questImage.sprite = null;
            Debug.LogWarning("QuestUI: Quest data not found in database!");
        }
    }
}
