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
    [SerializeField] private string photoPath;

    public void SetPhotoImage(Sprite photo, string filePath)
    {
        photoImage.sprite = photo;
        photoPath = filePath;
        isPhotoBeenFill = true;
        OnPhotoFillChanged?.Invoke(isPhotoBeenFill);
    }

    public void ResetPhoto()
    {
        photoImage.sprite = null;
        photoPath = null;
        isPhotoBeenFill = false;
        OnPhotoFillChanged?.Invoke(isPhotoBeenFill);
    }

    public bool IsPhotoBeenFill()
    {
        return isPhotoBeenFill;
    }

    public string GetFilePath()
    {
        return photoPath;
    }

    public Image GetPhotoImage()
    {
        return photoImage;
    }
}
