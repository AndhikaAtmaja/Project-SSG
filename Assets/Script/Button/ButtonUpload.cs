using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonUpload : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject CaptionScreen;
    [SerializeField] private GameObject PhotoScreen;
    [SerializeField] private Upload _uploadFeed;
    [SerializeField] private InputCaption _captionInput;

    [Header("State")]
    [SerializeField] private bool isPhotoBeenFill;
    [SerializeField] private bool isCaptionBeenFill;

    private void HandlePhotoFillChanged(bool filled)
    {
        isPhotoBeenFill = filled;
    }

    private void HandleCaptionFillChanged(bool filled)
    {
        isCaptionBeenFill = filled;
    }

    public void OnUpload()
    {
        if (isPhotoBeenFill && isCaptionBeenFill)
        {
            _uploadFeed.OnUploadPhoto(_captionInput.CaptionText.ToString());
            _captionInput.OnSubmit();
            SosialMediaManager.instance.UpdateSosialMedia();
            SosialMediaManager.instance.ChangeSosialMedia("Main");

            PhotoScreen.SetActive(true);
            CaptionScreen.SetActive(false);
        }
        else if (isPhotoBeenFill)
        {
            PhotoScreen.SetActive(false);
            CaptionScreen.SetActive(true);
        }
    }

    private void OnEnable()
    {
        if (SosialMediaManager.instance != null)
        {
            SosialMediaManager.instance.PhotoUI.OnPhotoFillChanged += HandlePhotoFillChanged;
        }

        if (_captionInput != null)
        {
            _captionInput.OnCaptionFillChanged += HandleCaptionFillChanged;
        }
    }

    private void OnDisable()
    {
        if (SosialMediaManager.instance != null)
        {
            SosialMediaManager.instance.PhotoUI.OnPhotoFillChanged -= HandlePhotoFillChanged;
        }

        if (_captionInput != null)
        {
            _captionInput.OnCaptionFillChanged -= HandleCaptionFillChanged;
        }
    }
}
