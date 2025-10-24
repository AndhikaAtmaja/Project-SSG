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

    public void SelectedChapter(string chapetName)
    {
        if (chapters.Count < 0)
            Debug.Log("There are no chapter been inster!");

        for (int i = 0; i < chapters.Count; i++)
        {
            if (chapters[i].nameChapter == chapetName)
            {
                currChapter = chapters[i];
                SetQuestList();
                SetDialogue();
            }
            else
            {
                Debug.Log("There are no chapter with that name!");
            }
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
        DialogueManager.instance.currDialogue = currChapter.dialogues[0];
    }

    public StoryChapterSO GetStoryChapter()
    {
        return currChapter;
    }
}
