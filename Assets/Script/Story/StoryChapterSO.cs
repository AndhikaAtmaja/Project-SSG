using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Story/Chapter")]
public class StoryChapterSO : ScriptableObject
{
    public string nameChapter;
    public List<StoryStep> chapterSteps;

    public bool isChapterDone;

}
