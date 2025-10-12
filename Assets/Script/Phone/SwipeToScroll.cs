using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SwipeToScroll : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [Header("Refenrences")]
    [SerializeField] private RectTransform panelRT;
    [SerializeField] private RectTransform maskArea;

    [Header("Settings")]
    [SerializeField] private float changeThreshold; 
    [SerializeField] private float snapSpeed;        
    [SerializeField] private int totalContentFeeds;

    [SerializeField] private int currentContent = 0;
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

        // Reverse the direction (drag up should move panel up visually)
        Vector2 newPos = panelRT.anchoredPosition - new Vector2(0, eventData.delta.y);

        float feedHeight = maskArea.rect.height;
        float minY = 0;
        float maxY = (totalContentFeeds - 1) * feedHeight;

        newPos.y = Mathf.Clamp(newPos.y, minY, maxY);
        panelRT.anchoredPosition = newPos;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (isAnimating) return;
        isDragging = false;

        float dragDistance = eventData.position.y - dragStartPos.y;
        float feedHeight = maskArea.rect.height;

        // Swipe up (dragDistance < 0) => next content
        if (Mathf.Abs(dragDistance) > changeThreshold)
        {
            if (dragDistance < 0 && currentContent < totalContentFeeds - 1)
            {
                // Swipe up -> next feed
                currentContent++;
            }
            else if (dragDistance > 0 && currentContent > 0)
            {
                // Swipe down -> previous feed
                currentContent--;
            }
        }

        float newTargetY = currentContent * feedHeight;
        StartCoroutine(SmoothMove(panelRT, new Vector2(0, newTargetY)));
    }

    IEnumerator SmoothMove(RectTransform target, Vector2 targetPos)
    {
        isAnimating = true;

        while (Vector2.Distance(target.anchoredPosition, targetPos) > 0.1f)
        {
            target.anchoredPosition = Vector2.Lerp(
                target.anchoredPosition,
                targetPos,
                Time.deltaTime * snapSpeed
            );
            yield return null;
        }

        target.anchoredPosition = targetPos;
        isAnimating = false;

        Debug.Log($"Changed to content {currentContent}");
    }

    public void SetTotalContentFeeds(int totalFeeds)
    {
        totalContentFeeds = totalFeeds;
    }
}
