using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    [SerializeField] List<GameObject> AreaSpawn;

    public static SpawnerManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogError($"There are to  many of {gameObject.name} in this game!");
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if (!string.IsNullOrEmpty(SceneManagement.instance.GetNextSpawn()))
        {
            SpawnPlayer(SceneManagement.instance.GetNextSpawn());
        }
    }

    public void SpawnPlayer(string spawnPosition)
    {
        if (AreaSpawn.Count > 0)
        {
            for (int i = 0; i < AreaSpawn.Count; i++)
            {
                if (AreaSpawn[i].name.ToLower() == spawnPosition.ToLower())
                {
                    //Spawn player on that area
                    SpawnCharacter.instance.SpawningCharacter(AreaSpawn[i].transform.position);
                    SceneManagement.instance.ResetDataScene();
                }
                else
                {
                    Debug.LogWarning($"there are no spawn with that name {spawnPosition}!");
                }
            }
        }
    }
}
