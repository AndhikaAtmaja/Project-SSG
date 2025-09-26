using UnityEngine;
using UnityEngine.Playables;

public class CheckDurationCutscene : MonoBehaviour
{
    [SerializeField] private PlayableDirector director;
    private bool isCutsceneDone;

    public bool GetCutSceneDone()
    {
        return isCutsceneDone;
    }

    private void OnEnable()
    {
        if (director != null)
            director.stopped += OnCutsceneStopped;
    }

    private void OnDisable()
    {
        if (director != null)
            director.stopped -= OnCutsceneStopped;
    }

    void OnCutsceneStopped(PlayableDirector pd)
    {
        isCutsceneDone = true;
    }
}
