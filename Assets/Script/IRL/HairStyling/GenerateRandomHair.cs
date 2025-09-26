using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateRandomHair : MonoBehaviour
{
    public static GenerateRandomHair Instance;

    [Header("Spawn Area")]
    public Collider2D AreaHair;

    [Header("Hair Prefabs")]
    [SerializeField] private List<GameObject> prefabsHairs;

    [Header("Settings && config")]
    [SerializeField] private int maxSafety;
    [SerializeField] private int minSpawned;
    [SerializeField] private int spawned;
    [SerializeField] private float checkRadius = 0.5f;
    [SerializeField] private LayerMask headMask;

    [SerializeField] private List<GameObject> spawnedHairs;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else
        {
            Destroy(gameObject);
        }
    }

    public void StartGenerateHair()
    {
        ResetSpawnHairs(); //reset

        int safety = 0;

        //generate game object at least 5 inside Area Hair
        while (spawned < minSpawned && safety < maxSafety)
        {
            safety++;

            //Generate Random Position inside Bound
            Bounds areaBound = AreaHair.bounds;
            Vector2 randomPos = new Vector2(
                Random.Range(areaBound.min.x, areaBound.max.x),
                Random.Range(areaBound.min.y, areaBound.max.y)
                );

            //Check randomPos if is inside playerhead or not
            bool isInsidePlayerHead = Physics2D.OverlapCircle(randomPos, checkRadius, headMask);

            //Generate hair in that RandomPos
            if (!isInsidePlayerHead)
            {
                GameObject prefabsHair = prefabsHairs[Random.Range(0, prefabsHairs.Count)];
                GameObject newHair = Instantiate(prefabsHair, randomPos, Quaternion.identity, AreaHair.transform);
                spawnedHairs.Add(newHair);
                spawned++;
            }

            // If we fail too many times, break to avoid freeze
            if (safety >= maxSafety && spawned < minSpawned)
            {
                Debug.LogWarning($"Stopped early: spawned {spawned}/{minSpawned} hairs.");
                break;
            }
        }
    }

    public void ResetSpawnHairs()
    {
        foreach (var hair in spawnedHairs)
            Destroy(hair);
        spawnedHairs.Clear();

        spawned = 0;
    }
}
