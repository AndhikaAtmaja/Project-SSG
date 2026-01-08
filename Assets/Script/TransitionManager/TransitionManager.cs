using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class TransitionManager : MonoBehaviour
{
    public static TransitionManager instance;

    public GameObject TransitionContainer;

    private SceneTransition[] sceneTransitions;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        sceneTransitions = TransitionContainer.GetComponentsInChildren<SceneTransition>();
    }

    public void PlayTransitionIn()
    {

    }
    public void PlayTransitionOut()
    {

    }

    public void LoadSceneTransition(string sceneName, string transitionName)
    {
        StartCoroutine(LoadSceneAsync(sceneName, transitionName));
    }

    private IEnumerator LoadSceneAsync(string sceneName, string transitionName)
    {
        SceneTransition transition = sceneTransitions.First(t => t.name == transitionName);

        AsyncOperation scene = SceneManager.LoadSceneAsync(sceneName);
        scene.allowSceneActivation = false;

        yield return transition.AnimateTransitionIn();

        //Loading bar

        yield return new WaitForSeconds(1f);

        scene.allowSceneActivation = true;

        yield return transition.AnimateTransitionOut();
    }
}
