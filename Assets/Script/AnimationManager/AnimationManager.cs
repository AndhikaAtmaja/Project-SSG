using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class AnimationManager : MonoBehaviour
{
    public static AnimationManager instance;

    public GameObject AnimationContainer;
    private PlayableDirector[] animations;

    [Header("Status")]
    [SerializeField] private bool isPlayingAnimation;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        animations = AnimationContainer.GetComponentsInChildren<PlayableDirector>();
    }

    public void PlayAnimation(string animationName, string transitionName)
    {

    }

    private IEnumerator PlayingAnimayion()
    {
        //play transition 
        TransitionManager.instance.PlayTransitionIn();

        //play animation

        //play transition
        TransitionManager.instance.PlayTransitionOut();

        yield return null;
    }
}
