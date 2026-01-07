using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phone : MonoBehaviour, IChangeScene
{
    public string transition;

    public void GetChangeScene()
    {
        SoundManager.instance.PlaySoundFXOneClip("Phone");

        if (GameManager.instance.GetCurrentScene() == "Bedroom")
        {
            SceneManagement.instance.OnChangeScene("Phone", "", transition);
        }
        else
        {
            SceneManagement.instance.OnChangeScene("Bedroom", "", transition);
        }
    }
}
