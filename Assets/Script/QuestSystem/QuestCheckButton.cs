using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestCheckButton : MonoBehaviour
{
    public QuestSO quest;
    public string questID;

    private void Start()
    {
        if (quest == null)
            quest = QuestManager.instance.FindQuestByID(questID);
        //this.gameObject.SetActive(false);
    }

    public void CompletedQuest()
    {
        QuestManager.instance.GetCheckQuest(quest.questID, true);
        if (SoundManager.instance.GetIsLoopSoundEffect())
            SoundManager.instance.StopLoopSoundEffect();
    }
}
