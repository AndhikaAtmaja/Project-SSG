using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationCharacter : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;

    [Header("Events")]
    public ActiveDeactiveSREventSO activeDeactiveSREvent;
    public ChangeAnimationSpriteEventSO changeAnimationSpriteEvent;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();

        ChangeAnimations();
    }

    private void ActiveorDeactiveSR(bool active)
    {
        _spriteRenderer.enabled = active;
    }

    private void ChangeAnimations()
    {
        if (!GameManager.instance.GetStatus("bath"))
        {
            _animator.SetBool("clean", false);
        }
        else
        {
            _animator.SetBool("clean", true);
        }
    }

    public void WalkAnimation(Vector2 direction)
    {
        if (direction.x < 0)
        {
            _spriteRenderer.flipX = true;
        }
        else if (direction.x > 0)
        {
            _spriteRenderer.flipX = false;
        }

        if (!GameManager.instance.GetStatus("bath"))
        {
            _animator.SetFloat("Walk-B-Bath", Mathf.Abs(direction.x));
        }
        else
        {
            _animator.SetFloat("Walk-A-Bath", Mathf.Abs(direction.x));
        }
    }

    private void OnEnable()
    {
        activeDeactiveSREvent.OnRaiseEvent += ActiveorDeactiveSR;
        changeAnimationSpriteEvent.OnRaiseEvent.AddListener(ChangeAnimations);
    }

    private void OnDisable()
    {
        activeDeactiveSREvent.OnRaiseEvent -= ActiveorDeactiveSR;
        changeAnimationSpriteEvent.OnRaiseEvent.RemoveListener(ChangeAnimations);
    }
}
