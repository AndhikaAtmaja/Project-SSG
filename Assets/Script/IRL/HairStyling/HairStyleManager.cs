using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HairStyleManager : MonoBehaviour
{
    [Header("Config && status HairStyle MiniGame")]
    private List<GameObject> hairs;
    private int playerCount;
    [SerializeField] private GameObject ChangeButton;
    [SerializeField] private QuestSO quest;
    public string questID;

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
        quest = QuestManager.instance.FindQuestByID(questID);
    }

    public void StartMiniGame()
    {
        //GenerateRandomHair.Instance.StartGenerateHair();
        Debug.Log($"There {hairs.Count} need apply to get style!");
        quest = QuestManager.instance.GetCurrentQuest();
    }

    public void AddPlayerCount()
    {
        playerCount++;
        Debug.Log($"{playerCount}/{hairs.Count}");

        if (playerCount >= hairs.Count)
        {
            //QuestManager.instance.GetCheckQuest(quest.questID, true);
            ChangeButton.SetActive(true);
        }
    }

    #region Automation total hair in-game
    private void OnEnable()
    {
     
        SceneManager.sceneLoaded += OnLoadedScene;
    }

    private void OnDisable()
    {
   
        SceneManager.sceneLoaded -= OnLoadedScene;
    }

    private void OnLoadedScene(Scene scene, LoadSceneMode mode)
    {
        if (hairs == null)
            hairs = new List<GameObject>();

        hairs.Clear();

        GameObject[] hair = GameObject.FindGameObjectsWithTag("hair");
        hairs.AddRange(hair);
        StartMiniGame();
    }
    #endregion
}
