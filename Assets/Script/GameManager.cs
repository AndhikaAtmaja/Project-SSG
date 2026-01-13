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
    public ChangeAnimationSpriteEventSO changeAnimationSpriteEvent;

    private StoryManager _storyManager;
    private QuestManager _questManager;
    private DialogueManager _dialogueManager;

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
        //instance all Manager
        //instance the currentQuest manager
        _questManager = Instantiate(questManagerPrefab).GetComponent<QuestManager>();

        //instance the dialogue manager
        _dialogueManager = Instantiate(dialogueManagerPrefab).GetComponent<DialogueManager>();

        //instance the story manager
        _storyManager = Instantiate(storyManagerPrefab).GetComponent<StoryManager>();
        SaveSystem.Load();
    }

    public void NewGame()
    {
        StoryManager.instance.ResetAllStoryProgress();
        SaveSystem.Save();
        StartGame();
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

            case "bath":
                isDoneTakeABath = condition;
                //Send Event to change skin
                changeAnimationSpriteEvent.Raise();
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
