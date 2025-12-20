using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationCharacter : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;

    [Header("Events")]
    public ActiveDeactiveSREventSO activeDeactiveSREvent;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void ActiveorDeactiveSR(bool active)
    {
        _spriteRenderer.enabled = active;
    }

    private void OnEnable()
    {
        activeDeactiveSREvent.OnRaiseEvent += ActiveorDeactiveSR;
    }

    private void OnDisable()
    {
        activeDeactiveSREvent.OnRaiseEvent -= ActiveorDeactiveSR;
    }
}
