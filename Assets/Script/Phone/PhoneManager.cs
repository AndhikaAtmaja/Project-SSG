using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneManager : MonoBehaviour
{
    public static PhoneManager Instance;

    [SerializeField] private bool isPhoneOpen;

    [SerializeField] private List<GameObject> PhoneScreens;

    [SerializeField] private GameObject currPhoneScreen;

    

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogError("There are to Phone Manager is this game!");
            Destroy(gameObject);
        }
    }

    public void OpenPhone()
    {
        currPhoneScreen = PhoneScreens[0];
    }

    public void ChangePhoneScreen(string ScreenName)
    {
        for (int i = 0; i < PhoneScreens.Count; i++)
        {
            if (PhoneScreens[i].name == "Phone-" + ScreenName)
            {
                GameObject nextScreen = PhoneScreens[i];
                currPhoneScreen.SetActive(false);
                currPhoneScreen = nextScreen;
                currPhoneScreen.SetActive(true);
            }
        }
    }

    public GameObject CurrPhoneScreen()
    {
        return currPhoneScreen;
    }

    public bool GetPhoneStatus()
    {
        return isPhoneOpen;
    }
}
