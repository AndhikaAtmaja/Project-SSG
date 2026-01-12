using System.Collections;
using UnityEngine;
using System.Linq;

public class AnimationManager : MonoBehaviour
{
    public static AnimationManager instance;

    public GameObject AnimationContainer;
    [SerializeField] private SceneAnimation[] animations;

    [Header("Status")]
    [SerializeField] private bool isPlayingAnimation;

    [Header("Events")]
    public AnimtionPlayingEventSO animtionPlayingEvent;

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
        animations = AnimationContainer.GetComponentsInChildren<SceneAnimation>();
    }

    public void PlayAnimation(string animationName)
    {
        StartCoroutine(PlayingAnimation(animationName));
    }

    private IEnumerator PlayingAnimation(string animtionName)
    {
        if (isPlayingAnimation)
            yield break;

        isPlayingAnimation = true;

        SceneAnimation animation = animations.First(t => t.name == animtionName);

        //play transition 
        yield return animation.AnimateTransitionIn();

        //play animation
        yield return animation.PlayAnimation();

        //play transition
        yield return animation.AnimateTransitionOut();
        isPlayingAnimation = false;
    }

    public bool isAnimtionPlaying()
    {
        return isPlayingAnimation;
    }
}
