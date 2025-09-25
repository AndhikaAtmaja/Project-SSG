using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCharacter : MonoBehaviour
{
    public static SpawnCharacter instance;

    private void Awake()
    {
        if (instance == null) 
            instance = this;
        else
        {
            Destroy(gameObject);
        }
    }

    public void SpawningCharacter(Vector2 positionSpawn)
    {
        transform.position = positionSpawn;
        Debug.Log($"Character succes get spawn at {positionSpawn}");
    }
}
