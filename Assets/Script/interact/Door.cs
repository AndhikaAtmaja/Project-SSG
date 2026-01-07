using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    public string nextScene;
    public string nextSpawnArea;
    public string transition;

    public void interact()
    {
        SceneManagement.instance.OnChangeScene(nextScene, nextSpawnArea, transition);

    }
}
