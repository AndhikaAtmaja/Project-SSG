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
    public string soundEffect;
    public string musicTrack;
    public StoryChapterSO nextChapter;

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
}
