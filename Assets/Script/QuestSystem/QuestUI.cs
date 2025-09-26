using UnityEngine;
using UnityEngine.UI;

public class QuestUI : MonoBehaviour
{
    [SerializeField] private GameObject questBox;
    [SerializeField] private Image questImage;

    //data base
    private QuestList _questList;
    [SerializeField] private QuestDataBase _questDB;

    private void Awake()
    {
        _questList = GameObject.FindGameObjectWithTag("QuestList").GetComponent<QuestList>();
        _questList.UpdateQuestList.AddListener(UpdateQuestUI);

        _questDB = GameObject.FindGameObjectWithTag("QuestDB").GetComponent<QuestDataBase>();
    }

    public void UpdateQuestUI()
    {
        if (_questDB == null || questImage == null)
        {
            if (_questDB == null)
                Debug.Log("Quest UI lost reference with data base");
            else if (questImage == null)
                Debug.Log("Quest UI lost reference with image");
            return;
        }

        string questID = _questList.GetCurrQuestID();
        QuestSO quest = _questDB.FindQuestData(questID);

        if (quest != null && quest.questImage != null)
        {
            if (!quest.GetisDone())
            {
                questBox.SetActive(true);
                questImage.sprite = quest.questImage;
            }
        }
        else
        {
            questBox.SetActive(false);
        }
    }
}
