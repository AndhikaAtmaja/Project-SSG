using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Events/Change Sprite Animation Event")]
public class ChangeAnimationSpriteEventSO : ScriptableObject
{
    public UnityEvent OnRaiseEvent = new UnityEvent();

    public void Raise()
    {
        OnRaiseEvent.Invoke();
    }
}
