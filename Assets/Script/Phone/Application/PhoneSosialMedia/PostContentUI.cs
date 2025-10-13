using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PostContentUI : MonoBehaviour
{
    [Header("Profile")]
    [SerializeField] private Image profilePicture;
    [SerializeField] private TextMeshProUGUI ProfileName;

    [Header("Content")]
    [SerializeField] private Image photoPostContent;
    [SerializeField] private TextMeshProUGUI captionContentFeed;

    public void SetPhotoPostContent(Sprite photoPost)
    {
        photoPostContent.sprite = photoPost;
    }

    public void SetCaptionContentFeed(string caption)
    {
        captionContentFeed.text = caption;
    }
}
