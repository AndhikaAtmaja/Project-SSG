using UnityEngine;
using UnityEngine.Events;

public class SetMassageInputAreaEventSO : ScriptableObject
{
    public UnityAction<Transform> OnRaiseArea;

    public void Raise(Transform massageInputArea)
    {
        OnRaiseArea?.Invoke(massageInputArea);
    }
}
