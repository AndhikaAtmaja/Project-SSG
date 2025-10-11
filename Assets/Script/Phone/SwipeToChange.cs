using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class SwipeToChange : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [Header("References")]
    [SerializeField] private RectTransform panelRT;
    [SerializeField] private RectTransform maskArea;

    [Header("Settings")]
    [SerializeField] private float changeThreshold;
    [SerializeField] private float snapSpeed;
    [SerializeField] private int totalPages;

    [SerializeField] private int currentPage;
    [SerializeField] private bool isDragging;
    [SerializeField] private bool isAnimating;
    private Vector2 dragStartPos;

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (isAnimating) return;
        isDragging = true;
        dragStartPos = eventData.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!isDragging || isAnimating)
            return;

        Vector2 newPos = panelRT.anchoredPosition + new Vector2(eventData.delta.x, 0);

        float maxOffset = maskArea.rect.width * (totalPages - 1);
        newPos.x = Mathf.Clamp(newPos.x, -maxOffset, 0);

        panelRT.anchoredPosition = newPos;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (isAnimating) return;

        isDragging = false;

        float dragDistance = eventData.position.x - dragStartPos.x;
        float pageWidth = maskArea.rect.width;

        if (Mathf.Abs(dragDistance) > changeThreshold)
        {
            if (dragDistance < -changeThreshold && currentPage < totalPages - 1)
                currentPage++; // move right
            else if (dragDistance > changeThreshold && currentPage > 0)
                currentPage--; // move left
        }

        float newTargetX = -currentPage * pageWidth;

        Debug.Log($"pageWidth : {pageWidth}" +
                  $" targetX : {newTargetX}" +
                  $" Current Page: {currentPage}");

        StartCoroutine(SmoothMove(panelRT, new Vector2(newTargetX, 0)));
    }

    IEnumerator SmoothMove(RectTransform targetScreen, Vector2 targetPos)
    {
        isAnimating = true;

        while (Vector2.Distance(targetScreen.anchoredPosition, targetPos) > 0.1f)
        {
            targetScreen.anchoredPosition = Vector2.Lerp(targetScreen.anchoredPosition, targetPos, Time.deltaTime * snapSpeed);
            yield return null;
        }

        targetScreen.anchoredPosition = targetPos;
        isAnimating = false;
        ChangeHomePageScreen();
    }


    private void ChangeHomePageScreen()
    {
        isDragging = false;
        Debug.Log($"Changed to page {currentPage}");
    }

/*    IEnumerator SnapBack()
    {
        while (Vector2.Distance(panelRT.anchoredPosition, startPos) > 0.1f){
            panelRT.anchoredPosition = Vector2.Lerp(panelRT.anchoredPosition, startPos, Time.deltaTime * snapSpeed);
            yield return null;
        }
        panelRT.anchoredPosition = startPos;
    }*/

/*    IEnumerator SlideOutAndReset()
    {
        Vector2 target = startPos + new Vector2((swipeRight ? 1 : -1) * maskArea.rect.width, 0);
        while (Vector2.Distance(panelRT.anchoredPosition, target) > 0.1f)
        {
            panelRT.anchoredPosition = Vector2.Lerp(panelRT.anchoredPosition, target, Time.deltaTime * snapSpeed);
            yield return null;
        }
        panelRT.anchoredPosition = startPos;
    }*/
}
