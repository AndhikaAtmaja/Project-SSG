using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneManager : MonoBehaviour
{
    public static PhoneManager Instance;

    [SerializeField] private bool isPhoneOpen;

    [SerializeField] private List<GameObject> PhoneScreens;

    [SerializeField] private GameObject currPhoneScreen;
    [SerializeField] private GameObject _buttonAccessibility;
    [SerializeField] private GameObject _notification;
    [SerializeField] private Transform MessageArea;
    [SerializeField] private Transform MessageInputArea;


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

    private void Start()
    {
        SetTransformArea();
        OnGetOpenPhone();
    }

    public void OnGetOpenPhone()
    {
        currPhoneScreen = PhoneScreens[0];

        if (PhoneScreens[0])
            _buttonAccessibility.SetActive(false);

        isPhoneOpen = true;
    }

    private void SetTransformArea()
    {
        DialogueManager.instance.SetMassageArea(MessageArea);
        DialogueManager.instance.SetMassageInputArea(MessageInputArea);
    }

    public void ChangePhoneScreen(string ScreenName)
    {
        for (int i = 0; i < PhoneScreens.Count; i++)
        {
            if (PhoneScreens[i].name == ScreenName)
            {
                GameObject nextScreen = PhoneScreens[i];
                currPhoneScreen.SetActive(false);
                currPhoneScreen = nextScreen;
                currPhoneScreen.SetActive(true);
            }
        }
        OnSetButtonAccessibility();
    }

    public void OnSetButtonAccessibility()
    {
        _buttonAccessibility.SetActive(true);
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
