using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "NotificationSO")]
public class NotificationSO : ScriptableObject
{
    public enum TypeEmotion
    {
        sad,
        happy,
        surprised,
        ask
    }

    [System.Serializable]
    public struct Notification
    {
        public string notificationName;
        [TextArea(5, 10)] public string notificationMassage;
    }

    public string notificationID;
    public string notificationName;
    public TypeEmotion emotion;
    public Notification[] notifications;
}
