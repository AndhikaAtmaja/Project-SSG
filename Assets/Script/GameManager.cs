using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private string currScene;

    [Header("reference")]
    public GameObject storyManagerPrefab;
    public GameObject questManagerPrefab;
    public GameObject dialogueManagerPrefab;

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
        //instance the story manager
        //instance the quest manager
        //instance the dialogue manager
        storyManagerInstance = Instantiate(storyManagerPrefab).GetComponent<StoryManager>();
        questManagerInstance = Instantiate(questManagerPrefab).GetComponent<QuestManager>();
        dialogueManagerInstance = Instantiate(dialogueManagerPrefab).GetComponent<DialogueManager>();
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
}
