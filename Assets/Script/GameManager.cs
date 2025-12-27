using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private string currScene;

    [Header("Game Status")]
    [SerializeField] private bool isMiniGameActive;
    [SerializeField] private bool isDoneMakeUp;
    [SerializeField] private bool isDoneTakeABath;

    [Header("reference")]
    public GameObject storyManagerPrefab;
    public GameObject questManagerPrefab;
    public GameObject dialogueManagerPrefab;

    [Header("Events")]
    public ActiveDeactiveSREventSO activeDeactiveSREvent;

    private StoryManager storyManagerInstance;
    private QuestManager questManagerInstance;
    private DialogueManager dialogueManagerInstance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void StartGame()
    {
        //instance the quest manager
        questManagerInstance = Instantiate(questManagerPrefab).GetComponent<QuestManager>();

        //instance the dialogue manager
        dialogueManagerInstance = Instantiate(dialogueManagerPrefab).GetComponent<DialogueManager>();

        //instance the story manager
        storyManagerInstance = Instantiate(storyManagerPrefab).GetComponent<StoryManager>();
        storyManagerInstance.StartChapter();
    }

    public string GetCurrentScene()
    {
        return currScene;
    }

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
        currScene = scene.name;
    }

    public void SetStatus(string nameEvent, bool condition)
    {
        string name = nameEvent.ToLower();

        switch (name)
        {
            case "minigame":
                isMiniGameActive = condition;
                activeDeactiveSREvent.Raise(!isMiniGameActive);
                break;

            case "makeup":
                isDoneMakeUp = condition;
                break;
        }
    }

    public bool GetStatus(string nameEvent)
    {
        string name = nameEvent.ToLower();

        switch (name)
        {
            case "minigame":
                return isMiniGameActive;

            case "makeup":
                return isDoneMakeUp;

            case "bath":
                return isDoneTakeABath;
        }

        return false;
    }

    public void ResetAllGameStatus()
    {
        isDoneTakeABath = isDoneMakeUp = false;
    }
}
