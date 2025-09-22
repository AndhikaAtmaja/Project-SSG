using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HairStyleManager : MonoBehaviour
{
    [Header("Config && status HairStyle MiniGame")]
    private int totalHair;

    public static HairStyleManager Instance;
    private void Awake()
    {
        if (Instance == null) Instance = this;
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        StartMiniGame();
    }

    public void StartMiniGame()
    {
        GenerateRandomHair.Instance.StartGenerateHair();
    }
}
