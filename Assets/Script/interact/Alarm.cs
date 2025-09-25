using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : IChangeScene
{
    [SerializeField] private string nextScene;
    [SerializeField] private string spawn;

    public void ChangeScene()
    {
        SceneManagement.instance.OnChangeScene(nextScene, spawn);
    }
}
