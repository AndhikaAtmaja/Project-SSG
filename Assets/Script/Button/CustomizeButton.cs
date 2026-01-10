using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CustomizeButton : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
{
    [Header("Button Config")]
    public Color hoverColor;
    public Color defaultColor;
    public float durationTween;
    public string soundEffect;
    [SerializeField] private bool isHovering;

    [Header("Button Events")]
    public UnityEvent onClick;
    public UnityEvent onHoverEnter;
    public UnityEvent onHoverExit;

    private Image _image;
    private float _defaultAlpha;
    private Tween _tween;

    private void Awake()
    {
        _image = GetComponent<Image>();
        defaultColor = _image.color;
        _defaultAlpha = _image.color.a;

        hoverColor.a = _defaultAlpha;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (isHovering) return;
        isHovering = true;
        OnHoverEnter();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        OnClick();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (!isHovering) return;
        isHovering = false;
        OnHoverExit();
    }

    private void OnHoverEnter()
    {
        _tween?.Kill();
        Sequence seq = DOTween.Sequence();
        seq.Join(_image.DOColor(hoverColor, durationTween));
        seq.Join(_image.DOFade(defaultColor.a, 0f));

        _tween = seq;
        onHoverEnter?.Invoke();
    }

    private void OnClick()
    {
        SoundManager.instance.PlaySoundFXOneClip(soundEffect);
        onClick?.Invoke();
    }

    private void OnHoverExit()
    {
        _tween?.Kill();

        Sequence seq = DOTween.Sequence();
        seq.Join(_image.DOColor(defaultColor, durationTween));

        _tween = seq;
        onHoverExit?.Invoke();
    }
}
