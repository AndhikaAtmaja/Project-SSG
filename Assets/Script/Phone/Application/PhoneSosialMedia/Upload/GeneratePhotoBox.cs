using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratePhotoBox : MonoBehaviour
{
    public GameObject PhotoBoxPrefab;
    [SerializeField] private Transform photoBoxArea;

    public void OnGeneratePhotoBox(Sprite photoSprite, string filePath)
    {
        GameObject newPhotoBox = Instantiate(PhotoBoxPrefab, photoBoxArea);

        PhotoBox photoBox = newPhotoBox.GetComponent<PhotoBox>();
        if (photoBox != null)
        {
            photoBox.SetPhotoImage(photoSprite, filePath);
        }
    }

    public void ClearPhotoBox()
    {
        foreach (Transform child in transform)
            Destroy(child.gameObject);
    }
}
