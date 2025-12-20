using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BathRoom : MonoBehaviour, IInteractable
{
    public string nameScene;

    public void interact()
    {
        SceneManagement.instance.OnChangeScene(nameScene, "");
    }
}
