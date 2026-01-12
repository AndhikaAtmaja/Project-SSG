using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Events/On Animation Playing Event")]

public class AnimtionPlayingEventSO : ScriptableObject
{
    public UnityAction<bool> OnAnimationPlaying;

    public void OnRaiseAnimationPlaying(bool isAnimationPlaying)
    {
        OnAnimationPlaying?.Invoke(isAnimationPlaying);
    }
}
