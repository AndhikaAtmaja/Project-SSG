using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public static SceneManagement instance;
    private string nextScene;
    private string nextSpawn;

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
        // Store where to go next
        nextSpawn = spawnArea;

        // Decide which scene to load
        string targetScene = string.IsNullOrEmpty(sceneName) ? SceneManager.GetActiveScene().name : $"Test-{sceneName}";

        SceneManager.LoadScene(targetScene);
    }

    public string GetNextSpawn()
    {
        return nextSpawn;
    }

    public void ResetDataScene()
    {
        nextScene = "";
        nextSpawn = "";
    }
}
