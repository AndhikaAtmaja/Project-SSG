using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToothBurshManager : MonoBehaviour
{
    public static ToothBurshManager instance;

    [Header("Config ToothBrush Minigame")]
    [SerializeField] private int totalStroke;
    [SerializeField] private int playerStroke;
    [SerializeField] private GameObject changeButton;

    private void Awake()
    {
        if (instance == null) instance = this;
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (playerStroke >= totalStroke & !ToothBrush.instance.GetIsPickUp())
        {
            changeButton.SetActive(true);
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
