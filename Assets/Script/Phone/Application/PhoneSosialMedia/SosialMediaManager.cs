using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SosialMediaManager : MonoBehaviour
{
    [Header("Refenrences")]
    [SerializeField] private SwipeToScroll _swipeToScroll;
    [SerializeField] private CountTotalFeed _countTotalFeed;

    public static SosialMediaManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
        }
    }

    public void UpdateSosialMedia()
    {
        if (_swipeToScroll == null || _countTotalFeed == null)
        {
            Debug.LogWarning("We are missing SwipeToScroll or CountTotalFeed!");
            return;
        }

        _swipeToScroll.SetTotalContentFeeds(_countTotalFeed.CountTotalFeeds());
    }

    private void Start()
    {
        if (_swipeToScroll == null || _countTotalFeed == null)
        {
            Debug.LogWarning("We are missing SwipeToScroll or CountTotalFeed!");
            return;
        }

        Debug.Log($"total Feeds = {_countTotalFeed.CountTotalFeeds()}");
    }
}
