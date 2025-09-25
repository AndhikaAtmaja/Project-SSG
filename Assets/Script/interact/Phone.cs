using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phone : MonoBehaviour, IChangeScene
{
    public void ChangeScene()
    {
        if (GameManager.instance.GetCurrentScene() == "Test-Bedroom")
        {
            SceneManagement.instance.OnChangeScene("Phone", "");
        }
        else
        {
            SceneManagement.instance.OnChangeScene("Bedroom", "");
        }
    }
}
