using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SwipeToUnlock : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [Header("References")]
    [SerializeField] private RectTransform panel;
    [SerializeField] private RectTransform maskArea;
    [SerializeField] private GameObject Password;

    [Header("Settings")]
    [SerializeField] private float unlockThreshold = 300f;
    [SerializeField] private float snapSpeed = 10f;
    [SerializeField] private bool swipeUp = true;

    private Vector2 startPos;
    [SerializeField] private bool unlock;

    // Start is called before the first frame update
    void Start()
    {
        startPos = panel.anchoredPosition;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (unlock) 
            return;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (unlock)
            return;

        Vector2 newPos = panel.anchoredPosition + new Vector2(0, eventData.delta.y);
        
        if (swipeUp)
            newPos.y = Mathf.Max(startPos.y, newPos.y);
        else
        {
            newPos.y = Mathf.Min(startPos.y, newPos.y);
        }

        float limit = maskArea.rect.height;
        newPos.y = Mathf.Clamp(newPos.y, startPos.y, startPos.y + limit);

        panel.anchoredPosition = newPos;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (unlock)
            return;

        float distance = Mathf.Abs(panel.anchoredPosition.y - startPos.y);

        if (distance >= unlockThreshold)
        {
            Unlock();
        }
        else
        {
            StartCoroutine(SnapBack());
        }
    }

    IEnumerator SnapBack()
    {
        while (Vector2.Distance(panel.anchoredPosition, startPos) > 0.1f)
        {
            panel.anchoredPosition = Vector2.Lerp(panel.anchoredPosition, startPos, Time.deltaTime * snapSpeed);
            yield return null;
        }
        panel.anchoredPosition = startPos;
    }

    private void Unlock()
    {
        unlock = true;
        Password.SetActive(true);
        Debug.Log("Unlocked!");
    }

    public bool GetUnlock()
    {
        return unlock;
    }
}
