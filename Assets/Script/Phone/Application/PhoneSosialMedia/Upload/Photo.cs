using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Photo : MonoBehaviour
{
    [SerializeField] private Image photoImage;
    [SerializeField] private GameObject UploadButton;

    private void Update()
    {
        if (photoImage != null)
            UploadButton.SetActive(true);
        else
        {
            UploadButton.SetActive(false);
        }
    }

    public void SetPhotoImage(Sprite photo)
    {
        photoImage.sprite = photo;
    }

    public Image GetPhotoImage()
    {
        return photoImage;
    }
}
