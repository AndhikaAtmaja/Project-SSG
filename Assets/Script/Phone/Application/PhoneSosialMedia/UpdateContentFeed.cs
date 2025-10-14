using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateContentFeed : MonoBehaviour
{
    [SerializeField] private Transform listContentFeeds;
    [SerializeField] private CountTotalFeed _countTotalFeed;

    public void AddContentFeeds()
    {
        int totalFeeds = _countTotalFeed.CountTotalFeeds();

        //Add from above the send to Sosial Media Manager
        
        SosialMediaManager.instance.ClearAllFeeds();
        
        for (int i = 0; i < totalFeeds; i++)
        {
            GameObject contentFeed = listContentFeeds.GetChild(i).gameObject;
            SosialMediaManager.instance.AddContentFeedToList(contentFeed);
        }
    }
}
