using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonContieStep : MonoBehaviour
{
    public void ContinueStep()
    {
        StoryManager.instance.CheckChapter();
    }
}
