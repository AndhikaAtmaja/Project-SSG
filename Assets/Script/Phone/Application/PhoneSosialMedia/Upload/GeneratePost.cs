using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratePost : MonoBehaviour
{
    [SerializeField] private GameObject contentPostPrefab;
    [SerializeField] private Transform containerContentPost;

    public void OnGenerateContentPost(Sprite photoContent, string caption)
    {
        GameObject newPostContent = Instantiate(contentPostPrefab, containerContentPost);

        newPostContent.transform.SetSiblingIndex(0);

        PostContentUI newPost = newPostContent.GetComponent<PostContentUI>();
        if (newPost != null)
        {
            newPost.SetPhotoPostContent(photoContent);
            newPost.SetCaptionContentFeed(caption);
        }
        SosialMediaManager.instance.updateContentFeed.AddNewContentFeedToList(newPostContent);
        Debug.Log("Try upload post");
    }
}
