using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhotoBox : MonoBehaviour
{
    [SerializeField] private Image photoImage;
    [SerializeField] private Photo photoUI;

    private void Awake()
    {
        GameObject GOphotoUI = GameObject.FindGameObjectWithTag("AreaPhoto");
        if (GOphotoUI != null)
        {
            photoUI = GOphotoUI.GetComponent<Photo>();
        }
    }

    public void SetPhotoImage(Sprite photo)
    {
        photoImage.sprite = photo;
        photoImage.preserveAspect = true;
    }

    public void SetPhoto()
    {
        if (photoUI != null)
        {
            photoUI.SetPhotoImage(photoImage.sprite);
        }
    }
}
