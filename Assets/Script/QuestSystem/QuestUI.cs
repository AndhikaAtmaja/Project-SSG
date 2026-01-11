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

    private void Start()
    {
        _questList = GameObject.FindGameObjectWithTag("QuestList").GetComponent<QuestList>();
    
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
            Debug.Log("QuestUI: All questChapter completed, hiding currentQuest UI.");
            return;
        }

        if (currentQuest != null)
        {
            if (currentQuest.IsCompleted)
            {
                //questBackGround.SetActive(false);
                questImage.sprite = null;
                Debug.Log($"QuestUI: Quest '{currentQuest.questName}' is done, hiding UI.");
            }
            else
            {
                // Show the current currentQuest info
                if (questBackGround != null)
                    questBackGround.SetActive(true);
                if (questImage != null)
                    questImage.sprite = currentQuest.questImage;
                if (questDesc != null)
                    questDesc.text = currentQuest.questName;
            }
        }
        else
        {
            Debug.LogWarning("QuestUI: Quest data not found in database!");
        }
    }
}
