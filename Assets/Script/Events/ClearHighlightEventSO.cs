using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Events/Clear Highlight Event")]
public class ClearHighlightEventSO : ScriptableObject
{
    public UnityEvent OnClearHighlight;

    public void RaiseClearHighlight() => OnClearHighlight?.Invoke();
}
