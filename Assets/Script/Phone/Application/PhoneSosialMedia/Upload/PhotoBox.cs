using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhotoBox : MonoBehaviour
{
    [SerializeField] private Image photoImage;

    public void SetPhotoImage(Sprite photo)
    {
        photoImage.sprite = photo;
        photoImage.preserveAspect = true;
    }
}
