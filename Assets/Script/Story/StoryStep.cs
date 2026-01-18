using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StoryStep
{
    public string nameStep;
    public string setpID;
    public List<QuestSO> quests;
    public List<DialogueSO> dialogues;
    public bool autoStartDialogueAfterScene;
    public string nextSceneName;
    public string transition;
    public StoryChapterSO nextChapter;

    [Header("Sound Config")]
    public string soundEffect;
    public bool isSoundEffectLoop;
    public string musicTrack;
    
    [Header("Chapter Step Status")]
    [SerializeField] private bool AllQuestDone;
    [SerializeField] private bool AllDialogueDone;

    public void QuestChecker()
    {
        bool Alldone = true;

        foreach (QuestSO s in quests)
        {
            if (s == null) continue;

            if (!s.IsCompleted)
            {
                Alldone = false;
                return;
            }
        }

        AllQuestDone = Alldone;
    }

    public void DialogueChecker()
    {
        //Debug.Log("Get Called");
        bool Alldone = true;
        foreach (DialogueSO s in dialogues)
        {
            if (s == null) continue;

            if (!s.isDialogueDone)
            {
                Alldone = false;
                return;
            }
        }

        AllDialogueDone = Alldone;
    }

    public bool GetAllDialogueDone()
    {
        //Debug.Log("Get Called GetAllDialogueDone");
        return AllDialogueDone;
    }
    public bool GetAllQuestDone()
    {
        //Debug.Log("Get Called GetAllQuestDone");
        return AllQuestDone;
    }

    public void ResetStoryProgress()
    {
        AllDialogueDone = AllQuestDone = false;

        if (quests != null)
        {
            foreach (QuestSO quest in quests)
            {
                if (quest == null) continue;

                quest.IsCompleted = false;

                if (quest.objectives == null) continue;

                foreach (QuestObjective questObj in quest.objectives)
                {
                    if (questObj == null) continue;
                    questObj.isCompleted = false;
                }
            }
        }


        if (dialogues != null)
        {
            foreach (DialogueSO dialogue in dialogues)
            {
                if (dialogue == null) continue;
                dialogue.isDialogueDone = false;
            }
        }
    }
}
