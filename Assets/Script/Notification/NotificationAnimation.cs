using DG.Tweening;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class NotificationAnimation : MonoBehaviour
{
    [SerializeField] private RectTransform panel; // your notification UI
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI messageText;
    [SerializeField] private float slideDuration = 0.5f;
    [SerializeField] private float stayDuration = 2f;
    [SerializeField] private float hiddenY = 200f;   // off-screen position
    [SerializeField] private float visibleY = -50f;  // visible position

    private Tween currentTween;

    [SerializeField] public static event Action<string> ShowCharacterEmotion;

    private void Start()
    {
        // Start hidden
        HideNotification();
    }

    public void ShowNotification(string name, string message, string emotion)
    {
        Debug.Log($"{name} : {message}");

        nameText.text = name;
        messageText.text = message;

        // Kill existing tween if any
        currentTween?.Kill();

        Sequence seq = DOTween.Sequence();
        seq.Append(panel.DOAnchorPosY(visibleY, slideDuration).SetEase(Ease.OutBack))
           .AppendInterval(stayDuration)
           .Append(panel.DOAnchorPosY(hiddenY, slideDuration).SetEase(Ease.InBack));

        currentTween = seq;
        ShowCharacterEmotion?.Invoke(emotion);
    }

    public void HideNotification()
    {
        panel.anchoredPosition = new Vector2(panel.anchoredPosition.x, hiddenY);
    }
}
