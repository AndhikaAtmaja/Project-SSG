using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Upload : MonoBehaviour
{
    [SerializeField] private GeneratePost generatePost;
    [SerializeField] private Photo photo;
    [SerializeField] private Image photoContent;

    public void OnUploadPhoto()
    {
        if (photoContent == null)
            photoContent = photo.GetPhotoImage();

        generatePost.OnGenerateContentPost(photoContent.sprite);
    }
}
