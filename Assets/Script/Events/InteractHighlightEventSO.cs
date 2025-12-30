using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Events/Interact Highlight Event")]
public class InteractHighlightEventSO : ScriptableObject
{
    public UnityAction<InteractTargetType, bool> OnHighlightEvent;

    public void RaiseHighlight(InteractTargetType highlight, bool isComplete)
    {
        OnHighlightEvent?.Invoke(highlight, isComplete);
    }
}
