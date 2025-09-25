using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PhoneApplication : MonoBehaviour
{
    public ApplicationSO ApplicationData;
    [SerializeField] private TextMeshProUGUI appName;
    [SerializeField] private Image appIcon;

    // Start is called before the first frame update
    void Start()
    {
        if (ApplicationData != null)
        {
            appName.text = ApplicationData.ApplicationName;
            //appIcon = ApplicationData.ApplicationIcon;
        }
    }

    public void OpenApplication()
    {
        PhoneManager.Instance.ChangePhoneScreen(ApplicationData.ApplicationName);
    }

}
