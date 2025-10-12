using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountTotalFeed : MonoBehaviour
{
    [SerializeField] private Transform listContents;
    [SerializeField] private int totalContentFeeds;

    public int CountTotalFeeds()
    {
        if (listContents == null)
        {
            Debug.LogWarning("Transfrom of list contents are missing!");
            return 0;
        }

        //Count total Gameobject in List Contents
        totalContentFeeds = listContents.childCount;
        return totalContentFeeds;
    }
}
