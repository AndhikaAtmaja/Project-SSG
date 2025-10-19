using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonChapter : MonoBehaviour
{
    [SerializeField] private string chapter;

   public void OnSelectChapter()
    {
        StoryManager.instance.SelectedChapter(chapter);
    }
}
