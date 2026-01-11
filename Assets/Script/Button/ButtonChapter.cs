using System;
using UnityEngine;
using UnityEngine.Events;

public class ButtonChapter : MonoBehaviour
{
    [SerializeField] private StoryChapterSO chapter;
    [SerializeField] private NotificationSO notification;
    [SerializeField] private NotificationAnimation _notificationAnimation;

    public static event Action<string> OnClickButton;

   public void OnSelectChapter()
    {
        StoryManager.instance.SelectedChapter(chapter.nameChapter);
        OnClickButton?.Invoke(gameObject.name);

        if (_notificationAnimation != null && notification != null)
        {
            _notificationAnimation.ShowNotification(notification.notificationName , "Message", notification.emotion.ToString());
        }
    }
}
