using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class PatternMGManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> RightOrderPattern;
    [SerializeField] private bool isCorrect;
    [SerializeField] private PlayerPattern _playerPattern;
    [SerializeField] private GameObject _nextScreenPhone;
    [SerializeField] private QuestSO quest;

    public static PatternMGManager Instance;

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
        quest = QuestManager.instance.FindQuestByID("PP");
    }

    public void CheckPatternOrder(List<GameObject> PlayerPattern)
    {
        isCorrect = true;
        int CountPlayerPattern = Mathf.Min(RightOrderPattern.Count, PlayerPattern.Count);

        for (int i = 0; i < CountPlayerPattern; i++)
        {
            if (RightOrderPattern[i] != PlayerPattern[i])
            {
                isCorrect = false;
                break;
            }
        }

        if (isCorrect && CountPlayerPattern == RightOrderPattern.Count)
        {
            //Debug.Log("Change to Home page Phone");
            PhoneManager.Instance.ChangePhoneScreen(_nextScreenPhone.name);
            QuestManager.instance.GetCheckQuest(quest.questID, isCorrect);
            ResetPatternPassword();
        }
        else
        {
            Debug.Log("Try Again");
            ResetPatternPassword();
        }
    }

    private void ResetPatternPassword()
    {
        _playerPattern.ResetPlayerPattern();
        PatternLine.Instance.ResetLinePattern();
        for (int i = 0; i < RightOrderPattern.Count; i++)
        {
            PatternPoint point = RightOrderPattern[i].GetComponent<PatternPoint>();
            point.ResetPoint();
        }
    }
}
