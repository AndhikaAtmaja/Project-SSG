using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratePhotoBox : MonoBehaviour
{
    public GameObject PhotoBoxPrefab;
    [SerializeField] private Transform photoBoxArea;

    public void OnGeneratePhotoBox(Sprite photoSprite)
    {
        GameObject newPhotoBox = Instantiate(PhotoBoxPrefab, photoBoxArea);

        PhotoBox photoBox = newPhotoBox.GetComponent<PhotoBox>();
        if (photoBox != null)
        {
            photoBox.SetPhotoImage(photoSprite);
        }
    }
}
