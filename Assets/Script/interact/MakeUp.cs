using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeUp : MonoBehaviour, IInteractable
{
    public void interact()
    {
        SceneManagement.instance.OnChangeScene("MakeUp", "");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
