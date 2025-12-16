using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeUp : MonoBehaviour, IInteractable
{
    public void interact()
    {
        SceneManagement.instance.OnChangeScene("MakeUp", "");
    }
}
