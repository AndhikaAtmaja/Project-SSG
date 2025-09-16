using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneApplication : MonoBehaviour
{
    public ApplicationSO ApplicationData;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OpenApplication()
    {
        PhoneManager.Instance.ChangePhoneScreen(ApplicationData.ApplicationName);
    }

}
