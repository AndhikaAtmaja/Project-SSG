using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryManager : MonoBehaviour
{
    public static StoryManager instance;

    [SerializeField] private List<StoryChapterSO> chapters;
    [SerializeField] private StoryChapterSO currChapter;

    [Header("Refences")]
    [SerializeField] private QuestList _questList;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SelectedChapter(string chapterName)
    {
        if (chapters == null || chapters.Count == 0)
        {
            Debug.LogWarning("No chapters assigned!");
            return;
        }

        StoryChapterSO found = chapters.Find(c => c.nameChapter == chapterName);
        if (found != null)
        {
            currChapter = found;
            SetQuestList();
            SetDialogue();
        }
        else
        {
            Debug.LogWarning($"No chapter found with the name '{chapterName}'");
        }
    }

    private void SetQuestList()
    {
        if (_questList == null)
        {
            _questList = GameObject.FindWithTag("QuestList").GetComponent<QuestList>();
        }

        _questList.SetQuestDataByChapter(currChapter.quests);
    }

    private void SetDialogue()
    {
        DialogueManager.instance.ChangeCurrentDialogue(currChapter.dialogues[0]);
    }

    public void CheckChapter()
    {
        if (currChapter == null) return;

        if (QuestIsDone() && DialogueIsDone())
        {
            currChapter.isChapterDone = true;
            Debug.Log($"Chapter '{currChapter.nameChapter}' completed! Move to next chapter.");
        }
    }

    private bool QuestIsDone()
    {
        foreach (var quest in currChapter.quests)
        {
            if (!quest.isDone)
                return false;
        }
        return true;
    }

    private bool DialogueIsDone()
    {
        foreach (var dialogue in currChapter.dialogues)
        {
            if (!dialogue.isDialogueDone)
                return false;
        }
        return true;
    }
}
