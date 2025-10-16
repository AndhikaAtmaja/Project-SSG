using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class ButtonAccessibility : MonoBehaviour, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] private GameObject secondButtonAccessibility;
    [SerializeField] private Image mainButtonAccessibility;

    private bool isButtonAccessibilityOpen;
    private bool isDrag;

    [Header("Animation Settings")]
    [SerializeField] private float animDuration = 0.3f;
    [SerializeField] private float scalePunch = 0.1f;

    public void onOpenToggleAccessibility()
    {
        if (isDrag) return; // Don’t open if dragging

        isButtonAccessibilityOpen = !isButtonAccessibilityOpen;

        if (isButtonAccessibilityOpen)
        {
            // Smooth open animation
            secondButtonAccessibility.SetActive(true);
            secondButtonAccessibility.transform.localScale = Vector3.zero;
            secondButtonAccessibility.transform.DOScale(Vector3.one, animDuration).SetEase(Ease.OutBack);
        }
        else
        {
            // Smooth close animation
            secondButtonAccessibility.transform.DOScale(Vector3.zero, animDuration)
                .SetEase(Ease.InBack)
                .OnComplete(() => secondButtonAccessibility.SetActive(false));
        }

        // Add a small punch effect for main button
        mainButtonAccessibility.transform.DOPunchScale(Vector3.one * scalePunch, 0.2f, 1, 0.5f);
    }

    public void OnCloseAppliaction()
    {
        PhoneManager.Instance.ChangePhoneScreen("New-Phone-HomePage");
    }

    // Called when dragging starts
    public void OnBeginDrag(PointerEventData eventData)
    {
        isDrag = true;
    }

    // Called when dragging ends
    public void OnEndDrag(PointerEventData eventData)
    {
        // Small delay to ensure it doesn’t trigger accidentally
        Invoke(nameof(ResetDrag), 0.1f);
    }

    private void ResetDrag()
    {
        isDrag = false;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        onOpenToggleAccessibility();
    }
}