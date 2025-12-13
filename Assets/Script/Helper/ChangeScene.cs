using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScene : MonoBehaviour, IChangeScene
{
    [SerializeField] private string nextScene;
    [SerializeField] private string spawn;

    public void GetChangeScene()
    {
        SceneManagement.instance.OnChangeScene(nextScene, spawn);
    }
}
