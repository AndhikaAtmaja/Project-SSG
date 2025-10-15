using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateContentFeed : MonoBehaviour
{
    [Header("Sosial Media Feeds")]
    [SerializeField] private List<GameObject> listContentFeeds;
    [SerializeField] private Transform contentFeedsTF;

    [SerializeField] private CountTotalFeed _countTotalFeed;

    public void SetContentFeeds()
    {
        int totalFeeds = _countTotalFeed.CountTotalFeeds();

        //Add from above the send to Sosial Media Manager

        ClearListofContentFeed();

        for (int i = contentFeedsTF.childCount - 1; i >= 0; i--)
        {
            GameObject contentFeed = contentFeedsTF.GetChild(i).gameObject;
            listContentFeeds.Add(contentFeed);
        }
    }

    public void AddNewContentFeedToList(GameObject contentFeed)
    {
        if (contentFeed == null)
        {
            Debug.LogWarning("Trying to add null contentFeed!");
            return;
        }

        // Prevent duplicates
        if (listContentFeeds.Contains(contentFeed))
        {
            Debug.Log("Feed already exists in the list!");
            return;
        }

        // Insert at top (index 0)
        listContentFeeds.Insert(0, contentFeed);
        contentFeed.transform.SetParent(contentFeedsTF, false);
        contentFeed.transform.SetSiblingIndex(0);

        // Update scroll system
        SosialMediaManager.instance.swipeToScroll.SetTotalContentFeeds(listContentFeeds.Count);

        Debug.Log($"[Feed Added] Total feeds now: {listContentFeeds.Count}");
    }

    public void ClearListofContentFeed()
    {
        listContentFeeds.Clear();
    }
}
