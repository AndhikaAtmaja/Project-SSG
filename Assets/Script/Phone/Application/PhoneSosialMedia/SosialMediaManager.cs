using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public struct SosialMedia
{
    public string nameArea;
    public bool isOpen;
    public GameObject sosialMediaGO;
}

public class SosialMediaManager : MonoBehaviour
{
    [Header("Sosial Media Area")]
    [SerializeField] private SosialMedia[] sosialMedias;
    [SerializeField] private SosialMedia _currSosialMedias;

    [Header("Sosial Media Feeds")]
    [SerializeField] private List<GameObject> listContentFeeds;
    [SerializeField] private UpdateContentFeed _updateContentFeeds;
    [SerializeField] private Transform _listContentFeeds;

    [Header("Refenrences")]
    [SerializeField] private SwipeToScroll _swipeToScroll;
    [SerializeField] private CountTotalFeed _countTotalFeed;
    [SerializeField] private Photo _photoUI;
    public Photo PhotoUI => _photoUI;
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

        RefreshAllSosialMedia();

        _swipeToScroll.SetTotalContentFeeds(_countTotalFeed.CountTotalFeeds());
    }

    public void RefreshAllSosialMedia()
    {
        for (int i = 0; i < sosialMedias.Length; i++)
        {
            if (i == 0)
            {
                sosialMedias[i].sosialMediaGO.SetActive(sosialMedias[i].isOpen = true);
                _currSosialMedias = sosialMedias[i];
            }
            else
                sosialMedias[i].sosialMediaGO.SetActive(sosialMedias[i].isOpen = false);
        }
    }

    public void ChangeSosialMedia(string targetName)
    {
        if (sosialMedias.Length == 0)
        {
            Debug.LogWarning("There are no List of Area sosial media in sosial Medias");
            return;
        }

        bool found = false;
        int newIndex = -1;

        // Step 1: Loop through all sosialMedias
        for (int i = 0; i < sosialMedias.Length; i++)
        {
            // If this one is the currently open one, close it
            if (_currSosialMedias.nameArea == sosialMedias[i].nameArea)
            {
                if (sosialMedias[i].nameArea == "SosialMedia-Upload")
                {
                    PhotoUI.ResetPhoto();
                }

                sosialMedias[i].sosialMediaGO.SetActive(false);
                sosialMedias[i].isOpen = sosialMedias[i].sosialMediaGO.activeSelf;
            }

            // If this one matches the target name, mark it for activation
            if (sosialMedias[i].nameArea == $"SosialMedia-{targetName}")
            {
                newIndex = i;
                found = true;
            }
        }

        // Step 2: If target found, open it
        if (found && newIndex != -1)
        {
            sosialMedias[newIndex].sosialMediaGO.SetActive(true);
            sosialMedias[newIndex].isOpen = sosialMedias[newIndex].sosialMediaGO.activeSelf;
            _currSosialMedias = sosialMedias[newIndex];
        }
        else
        {
            Debug.LogWarning($"No SosialMedia found with name: {targetName}");
        }
    }

    public SosialMedia GetCurrSosialMedias()
    {
        return _currSosialMedias;
    }

    private void Start()
    {
        if (_swipeToScroll == null || _countTotalFeed == null)
        {
            Debug.LogWarning("We are missing SwipeToScroll or CountTotalFeed!");
            return;
        }

        Debug.Log($"total Feeds = {_countTotalFeed.CountTotalFeeds()}");
        RefreshAllSosialMedia();
    }

    public void ClearListofContentFeed()
    {
        listContentFeeds.Clear();
    }

    public void AddContentFeedToList(GameObject contentFeed)
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
        contentFeed.transform.SetParent(_listContentFeeds, false);
        contentFeed.transform.SetSiblingIndex(0);

        // Update scroll system
        _swipeToScroll.SetTotalContentFeeds(listContentFeeds.Count);

        Debug.Log($"[Feed Added] Total feeds now: {listContentFeeds.Count}");
    }

    public void ClearAllFeeds()
    {
        foreach (var feed in listContentFeeds)
        {
            Destroy(feed);
        }
        listContentFeeds.Clear();
    }

}
