using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChapterUI : MonoBehaviour
{
    [SerializeField] private StoryChapterSO _storyChapterSO;
    public TextMeshProUGUI chapterNameUI;

    private void Start()
    {
        chapterNameUI.text = _storyChapterSO.nameChapter;
    }
}
