using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phone : MonoBehaviour, IChangeScene
{
    public void GetChangeScene()
    {
        SoundManager.instance.PlaySoundFXOneClip("Phone");

        if (GameManager.instance.GetCurrentScene() == "Bedroom")
        {
            SceneManagement.instance.OnChangeScene("Phone", "");
        }
        else
        {
            SceneManagement.instance.OnChangeScene("Bedroom", "");
        }
    }
}
