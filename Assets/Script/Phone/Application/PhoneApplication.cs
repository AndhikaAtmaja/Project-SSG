using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PhoneApplication : MonoBehaviour
{
    public ApplicationSO ApplicationData;
    [SerializeField] private TextMeshProUGUI appName;
    [SerializeField] private Image appIcon;

    public static event Action<string> OnApplicationOpenned;

    // Start is called before the first frame update
    void Start()
    {
        if (ApplicationData != null)
        {
            appName.text = ApplicationData.ApplicationName;
            appIcon.sprite = ApplicationData.ApplicationIcon;
        }
    }

    public void OpenApplication()
    {
        PhoneManager.Instance.ChangePhoneScreen($"New-Phone-{ApplicationData.ApplicationName}");
        OnApplicationOpenned?.Invoke(ApplicationData.ApplicationName);
    }

}
