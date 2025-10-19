using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhotoBox : MonoBehaviour
{
    [SerializeField] private Image photoImage;
    [SerializeField] private Photo photoUI;
    [SerializeField] private string photoPath;

    private void Awake()
    {
        GameObject GOphotoUI = GameObject.FindGameObjectWithTag("AreaPhoto");
        if (GOphotoUI != null)
        {
            photoUI = GOphotoUI.GetComponent<Photo>();
        }
    }

    public void SetPhotoImage(Sprite photo, string filePath)
    {
        photoImage.sprite = photo;
        photoPath = filePath;

        photoImage.preserveAspect = true;
    }

    public void SetPhoto()
    {
        if (photoUI != null)
        {
            photoUI.SetPhotoImage(photoImage.sprite, photoPath);
        }
    }
}
