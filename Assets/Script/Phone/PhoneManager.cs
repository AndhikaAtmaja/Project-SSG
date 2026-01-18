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

    public GameObject[] ListofButtonChapters;
    public List<GameObject> ListOfContact;

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

    public void UpdateListChapter()
    {
        //Hide all 
        foreach (GameObject chapterButton in ListofButtonChapters)
            chapterButton.SetActive(false);

        string nameChapter = StoryManager.instance.GetCurrentStroy().nameChapter;

        //find the right chapter
        for (int i = 0;i < ListofButtonChapters.Length; i++)
        {
            ButtonChapter chapterButton = ListofButtonChapters[i].GetComponent<ButtonChapter>();
            if (chapterButton != null)
            {
                if (chapterButton.currentChapter.nameChapter == nameChapter)
                {
                    ListofButtonChapters[i].SetActive(true);
                }
            }
        }
    }

    private string NormalizeStepName(string stepName)
    {
        // Remove trailing numbers (and spaces before them)
        return System.Text.RegularExpressions.Regex.Replace(stepName, @"\s*\d+$", "");
    }

    public void UpdateContactMassage()
    {
        //Hide all 
        foreach (GameObject contactButton in ListOfContact)
            contactButton.SetActive(false);

        string nameStep = NormalizeStepName(StoryManager.instance.currentStep.nameStep);
            
        //find the right chapter
        for (int i = 0; i < ListOfContact.Count; i++)
        {
            ButtonDilaoge contactButton = ListOfContact[i].GetComponent<ButtonDilaoge>();
            if (contactButton != null)
            {
                if (contactButton.nameStep == nameStep)
                {
                    ListOfContact[i].SetActive(true);
                }
            }
        }
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
