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
    [SerializeField] private UpdateContentFeed _updateContentFeeds;
    public UpdateContentFeed updateContentFeed => _updateContentFeeds;
    

    [Header("Refenrences")]
    [SerializeField] private SwipeToScroll _swipeToScroll;
    public SwipeToScroll swipeToScroll => _swipeToScroll;

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
        if (_updateContentFeeds == null)
        {
            Debug.LogWarning("We are missing SwipeToScroll or CountTotalFeed!");
            return;
        }

        RefreshAllSosialMedia();

        _swipeToScroll.SetTotalContentFeeds(_countTotalFeed.CountTotalFeeds());
        Debug.Log($"total Feeds = {_countTotalFeed.CountTotalFeeds()}");
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

        _updateContentFeeds.SetContentFeeds();

    }
}
