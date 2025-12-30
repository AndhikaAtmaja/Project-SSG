using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToothBurshManager : MonoBehaviour
{
    public static ToothBurshManager instance;

    public GameObject miniGame;
    public GameObject Environment;

    [Header("Config ToothBrush Minigame")]
    [SerializeField] private int totalStroke;
    [SerializeField] private int playerStroke;
    [SerializeField] private bool isActive;
    [SerializeField] private GameObject changeButton;

    private void Awake()
    {
        if (instance == null) instance = this;
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        QuestManager.instance.HighlightArea();
    }

    private void Update()
    {
        if (isActive)
        {
            if (playerStroke >= totalStroke)
            {
                GameManager.instance.SetStatus("minigame", isActive);
                changeButton.SetActive(true);
            }
        }
    }

    public void ActivedMiniGame()
    {
        isActive = true;
        GameManager.instance.SetStatus("minigame", isActive);
        if (isActive == !isActive)
        {
            miniGame.SetActive(isActive);
            //Environment.SetActive(false);
        }
        else
        {
            miniGame.SetActive(isActive);
            //Environment.SetActive(true);
        }

    }

    public void DeactiveMiniGame()
    {
        isActive = false;
        GameManager.instance.SetStatus("minigame", isActive);
        GameManager.instance.SetStatus("bath", true);
        if (isActive == !isActive)
        {
            miniGame.SetActive(isActive);
            //Environment.SetActive(false);
        }
        else
        {
            miniGame.SetActive(isActive);
            //Environment.SetActive(true);
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
