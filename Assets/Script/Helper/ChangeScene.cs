using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScene : MonoBehaviour, IChangeScene
{
    [SerializeField] private string nextScene;
    [SerializeField] private string spawn;

    public static event Action<string> OnChangeScene;

    public void GetChangeScene()
    {
        SceneManagement.instance.OnChangeScene(nextScene, spawn);
        OnChangeScene?.Invoke(nextScene);
    }
}
