using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Story/Chapter")]
public class StoryChapterSO : ScriptableObject
{
    public string nameChapter;

    public List<QuestSO> quests;

    public List<DialogueSO> dialogues;

    public bool isChapterDone;

}
