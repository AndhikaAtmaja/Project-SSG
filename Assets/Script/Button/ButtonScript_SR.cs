using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

public class ButtonScript_SR : MonoBehaviour
{
    [Header("Button Sprite Renderer")]
    public Color baseColor;
    public Color highlightColor;
    public float durationColor;
    public float scaleUP;
    public float durationScale;

    [Header("Config")]
    private bool isHover;

    [Header("Events")]
    public UnityEvent onClick;

    private SpriteRenderer sr;
    private Tween colorTween;
    private Tween scaleTween;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void OnMouseEnter()
    {
        isHover = true;
        while (isHover)
        {
            colorTween?.Kill();
            colorTween = sr.DOColor(highlightColor, durationColor);

            scaleTween?.Kill();
            scaleTween = transform.DOScale(scaleUP, durationScale).SetEase(Ease.OutBack);
        }
    }

    private void OnMouseExit()
    {
        colorTween?.Kill();
        colorTween = sr.DOColor(baseColor, durationColor);

        scaleTween?.Kill();
        scaleTween = transform.DOScale(0.2f, durationScale).SetEase(Ease.OutBack);
    }

    private void OnMouseDown()
    {
        //Do something or call that this object need do something
        onClick?.Invoke();
    }
}
