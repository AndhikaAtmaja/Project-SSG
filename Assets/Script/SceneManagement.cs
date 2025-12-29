using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public static SceneManagement instance;
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

    public void OnChangeScene(string sceneName, string spawnArea)
    {
        Debug.Log($"name scene : {sceneName}");
        if (!DialogueManager.instance.isDialogueActive())
        {
            // Store where to go next
            nextSpawn = spawnArea;

            // Decide which scene to load
            string targetScene = string.IsNullOrEmpty(sceneName) ? SceneManager.GetActiveScene().name : $"Test-{sceneName}";

            SceneManager.LoadScene(targetScene);
            OnSuccesChangeScene?.Invoke(sceneName);
        }
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
