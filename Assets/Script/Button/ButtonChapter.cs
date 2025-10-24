using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonChapter : MonoBehaviour
{
    [SerializeField] private string chapter;
    [SerializeField] private NotificationAnimation _notificationAnimation;

   public void OnSelectChapter()
    {
        StoryManager.instance.SelectedChapter(chapter);

        if (_notificationAnimation != null)
        {
            _notificationAnimation.ShowNotification("Lala", "Message");
        }
    }
}
