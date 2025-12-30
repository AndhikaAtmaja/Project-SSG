using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public static SceneManagement instance;
    
    [SerializeField] private string _currentScene;
    [SerializeField] private string _lastScene;
    private string nextSpawn;

    public static event Action<string> OnSuccesChangeScene;

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

    private void Start()
    {
        Scene scene =  SceneManager.GetActiveScene();

        if (scene.name.ToLower() != "mainmenu")
            _currentScene = scene.name;
    }

    public void OnChangeScene(string sceneName, string spawnArea)
    {
        //Debug.Log($"name scene : {sceneName}");
        _lastScene = _currentScene;
        if (!DialogueManager.instance.isDialogueActive())
        {
            // Store where to go next
            nextSpawn = spawnArea;

            // Decide which scene to load
            string targetScene = string.IsNullOrEmpty(sceneName) ? SceneManager.GetActiveScene().name : sceneName;

            SceneManager.LoadScene(targetScene);
            _currentScene = sceneName;
            OnSuccesChangeScene?.Invoke(sceneName);
        }
    }

    public void Save(ref SceneGameSaveData data)
    {
        data.currentScene = _currentScene;
    }

    public void Load(SceneGameSaveData data)
    {
        if (!string.IsNullOrEmpty(data.currentScene))
            OnChangeScene(data.currentScene, "");
        else
            OnChangeScene("WakeUp", "");
    }

    public string GetNextSpawn()
    {
        return nextSpawn;
    }

    public void ResetDataScene()
    {
        nextSpawn = "";
    }
}


[System.Serializable]
public struct SceneGameSaveData
{
    public string currentScene;
}
