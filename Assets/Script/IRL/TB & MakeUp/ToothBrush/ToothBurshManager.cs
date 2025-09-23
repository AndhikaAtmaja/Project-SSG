using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToothBurshManager : MonoBehaviour
{
    public static ToothBurshManager Instance;

    [Header("Config ToothBrush Minigame")]
    [SerializeField] private int totalStroke;
    [SerializeField] private int playerStroke; 

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else
        {
            Destroy(gameObject);
        }
    }

    public void BrushingTooth()
    {
        if (playerStroke >= totalStroke)
        {
            Debug.Log("Done cleaning");
        }
        else if (playerStroke < totalStroke)
        {
            playerStroke++;
            Debug.Log($"{playerStroke} / {totalStroke}");
        }
    }
}
