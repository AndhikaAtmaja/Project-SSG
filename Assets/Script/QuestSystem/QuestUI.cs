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
        if (currentQuest == null || currentQuest.IsCompleted)
        {
            if (questBackGround != null)
                questBackGround.SetActive(false);

            if (questImage != null)
                questImage.sprite = null;

            if (questDesc != null)
                questDesc.text = "";

            Debug.Log("QuestUI: No active quest, hiding UI.");
            return;
        }
        if (questBackGround != null)
            questBackGround.SetActive(true);

        if (questImage != null)
            questImage.sprite = currentQuest.questImage;

        if (questDesc != null)
            questDesc.text = currentQuest.questName;
    }
}
