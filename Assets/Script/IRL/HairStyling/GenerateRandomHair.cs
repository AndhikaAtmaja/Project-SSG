using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateRandomHair : MonoBehaviour
{
    [Header("Spawn Area")]
    public Collider2D AreaHair;

    [Header("Hair Prefabs")]
    [SerializeField] private List<GameObject> prefabsHairs;

    [Header("Settings && config")]
    [SerializeField] private int safety;
    [SerializeField] private int minSpawned;
    [SerializeField] private int spawned;
    [SerializeField] private int minHairCount = 5;
    [SerializeField] private float checkRadius = 0.5f;
    [SerializeField] private LayerMask headMask;

    [SerializeField] private List<GameObject> spawnedHairs;

    private void Start()
    {
        StartGenerateHair();
    }

    public void StartGenerateHair()
    {
        ResetSpawnHairs(); //reset

        //generate game object at least 5 inside Area Hair
        while (spawned < minSpawned && safety > 0)
        {
            safety--;

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
        }
    }

    public void ResetSpawnHairs()
    {
        spawnedHairs.Clear();
    }
}
