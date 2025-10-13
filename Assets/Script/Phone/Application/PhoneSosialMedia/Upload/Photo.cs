using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Photo : MonoBehaviour
{
    [SerializeField] private Image photoImage;
    public event Action<bool> OnPhotoFillChanged;
    [SerializeField] private bool isPhotoBeenFill;
    [SerializeField] private GameObject UploadButton;

    public void SetPhotoImage(Sprite photo)
    {
        photoImage.sprite = photo;
        isPhotoBeenFill = true;
        OnPhotoFillChanged?.Invoke(isPhotoBeenFill);
    }

    public void ResetPhoto()
    {
        photoImage.sprite = null;
        isPhotoBeenFill = false;
        OnPhotoFillChanged?.Invoke(isPhotoBeenFill);
    }

    public bool IsPhotoBeenFill()
    {
        return isPhotoBeenFill;
    }

    public Image GetPhotoImage()
    {
        return photoImage;
    }
}
