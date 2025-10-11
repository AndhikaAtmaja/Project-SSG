using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SwipeToUnlock : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [Header("References")]
    [SerializeField] private RectTransform panelRT;
    [SerializeField] private RectTransform maskArea;
    [SerializeField] private GameObject passwordGO;
    [SerializeField] private GameObject panelGO;

    [Header("Settings")]
    [SerializeField] private float unlockThreshold = 300f;
    [SerializeField] private float snapSpeed = 10f;
    [SerializeField] private bool swipeUp = true;

    private Vector2 startPos;
    [SerializeField] private bool unlock;

    // Start is called before the first frame update
    void Start()
    {
        startPos = panelRT.anchoredPosition;
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

        Vector2 newPos = panelRT.anchoredPosition + new Vector2(0, eventData.delta.y);
        
        if (swipeUp)
            newPos.y = Mathf.Max(startPos.y, newPos.y);
        else
        {
            newPos.y = Mathf.Min(startPos.y, newPos.y);
        }

        float limit = maskArea.rect.height;
        newPos.y = Mathf.Clamp(newPos.y, startPos.y, startPos.y + limit);

        panelRT.anchoredPosition = newPos;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (unlock)
            return;

        float distance = Mathf.Abs(panelRT.anchoredPosition.y - startPos.y);

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
        while (Vector2.Distance(panelRT.anchoredPosition, startPos) > 0.1f)
        {
            panelRT.anchoredPosition = Vector2.Lerp(panelRT.anchoredPosition, startPos, Time.deltaTime * snapSpeed);
            yield return null;
        }
        panelRT.anchoredPosition = startPos;
    }

    private void Unlock()
    {
        unlock = true;
        passwordGO.SetActive(true);
        panelGO.SetActive(false);
        Debug.Log("Unlocked!");
    }

    public bool GetUnlock()
    {
        return unlock;
    }
}
