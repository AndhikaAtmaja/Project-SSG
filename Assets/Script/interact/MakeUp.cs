using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeUp : Interact, IInteractable
{
    public void interact()
    {
        SceneManagement.instance.OnChangeScene("MakeUp", "");
    }
}
