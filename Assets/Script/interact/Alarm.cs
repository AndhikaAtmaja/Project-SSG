using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private CheckDurationCutscene checkDurationCutscene;
    [SerializeField] private GameObject alarm;

    private void Update()
    {
        if (checkDurationCutscene.GetCutSceneDone())
        {
            alarm.SetActive(true);
        }
    }
}
