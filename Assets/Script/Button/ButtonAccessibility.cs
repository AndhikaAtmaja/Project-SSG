using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;


public class ButtonAccessibility : MonoBehaviour
{
    [SerializeField] private GameObject secondButtonAccessibility;
    [SerializeField] private Image mainButtonAccessibility;

    private bool isButtonAccessibilityOpen;

    public void onOpenToggleAccessibility()
    {
        isButtonAccessibilityOpen = !isButtonAccessibilityOpen;

        secondButtonAccessibility.SetActive(isButtonAccessibilityOpen);
    }

    public void OnCloseAppliaction()
    {
        PhoneManager.Instance.ChangePhoneScreen("New-Phone-HomePage");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        onOpenToggleAccessibility();
    }
}