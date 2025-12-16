using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Events/Set Massage Area Event")]
public class SetMassageAreaEventSO : ScriptableObject
{
    public UnityAction<Transform> OnRaiseArea;

    public void Raise (Transform massageArea)
    {
        OnRaiseArea?.Invoke(massageArea);
    }
}
