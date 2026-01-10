using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public InteractTargetType interactType;

    public Sprite defaultSprite;
    public Sprite highlightSprite;

    [Header("Events")]
    public InteractHighlightEventSO interactHighligh;
    public ClearHighlightEventSO clearHighlight;

    private SpriteRenderer _sr;

    private void Awake()
    {
        _sr = GetComponent<SpriteRenderer>();
        _sr.sprite = defaultSprite;
    }

    private void Highlight(InteractTargetType interactType, bool isComplete)
    {
        //Debug.Log("get Called");
        if (interactType == this.interactType && !isComplete)
        {
            _sr.sprite = highlightSprite;
        }
    }

    private void BacktoDefault()
    {
        _sr.sprite = defaultSprite;
    }

    private void OnEnable()
    {
        interactHighligh.OnHighlightEvent += Highlight;
        clearHighlight.OnClearHighlight.AddListener(BacktoDefault);
    }

    private void OnDisable()
    {
        interactHighligh.OnHighlightEvent -= Highlight;
        clearHighlight.OnClearHighlight.RemoveListener(BacktoDefault);

    }
}
