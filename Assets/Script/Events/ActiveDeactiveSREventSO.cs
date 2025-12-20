using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Events/ Active Deactive SR Event")]

public class ActiveDeactiveSREventSO : ScriptableObject
{
    public UnityAction<bool> OnRaiseEvent;

   public void Raise(bool isActive)
    {
        OnRaiseEvent?.Invoke(isActive);
    }
}
