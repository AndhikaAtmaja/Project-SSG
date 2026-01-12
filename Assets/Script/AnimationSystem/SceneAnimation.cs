using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public abstract class SceneAnimation : MonoBehaviour
{
    public PlayableDirector director;

    private void Start()
    {
        director = GetComponent<PlayableDirector>();
    }

    public abstract IEnumerator AnimateTransitionIn();
    public abstract IEnumerator PlayAnimation();
    public abstract IEnumerator AnimateTransitionOut();
}
