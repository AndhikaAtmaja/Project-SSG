using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterNotification : MonoBehaviour
{
    public CharacterEmotion emotionArea;

    public void HandelCharacterEmotion(string emotion)
    {
        emotionArea.ShowEmotion(emotion.ToLower());
        Debug.Log($"there to showing emotion of {emotion.ToLower()}");
    }

    private void OnEnable()
    {
        NotificationAnimation.ShowCharacterEmotion += HandelCharacterEmotion;
    }

    private void OnDisable()
    {
        NotificationAnimation.ShowCharacterEmotion -= HandelCharacterEmotion;
    }
}
