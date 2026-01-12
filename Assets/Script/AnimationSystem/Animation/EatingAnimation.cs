using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.Playables;

public class EatingAnimation : SceneAnimation
{
    public CanvasGroup _canvasGroup;
    public float durationAnimtionTransition;

    public override IEnumerator AnimateTransitionIn()
    {
        Debug.Log("AnimateTransitionIn EatingAnimation");
        var tween = _canvasGroup.DOFade(1f, durationAnimtionTransition);
        yield return tween.WaitForCompletion();
    }

    public override IEnumerator PlayAnimation()
    {
        director.time = 0;
        director.Play();

        yield return new WaitUntil(() => director.state != PlayState.Playing);
    }

    public override IEnumerator AnimateTransitionOut()
    {
        var tween = _canvasGroup.DOFade(0f, durationAnimtionTransition);
        yield return tween.WaitForCompletion();
    }
}
