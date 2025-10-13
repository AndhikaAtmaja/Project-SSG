using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class InputCaption : MonoBehaviour
{
    [SerializeField] private TMP_InputField captionInput;
    public event Action<bool> OnCaptionFillChanged;
    [SerializeField] private bool isCaptionBeenFill;

    public string CaptionText => captionInput.text;

    private void Awake()
    {
        // Subscribe to the text change event
        captionInput.onValueChanged.AddListener(OnCaptionChanged);
    }

    private void OnDestroy()
    {
        // Unsubscribe to prevent memory leaks
        captionInput.onValueChanged.RemoveListener(OnCaptionChanged);
    }

    private void OnCaptionChanged(string text)
    {
        bool filled = !string.IsNullOrEmpty(text);
        if (filled != isCaptionBeenFill)
        {
            isCaptionBeenFill = filled;
            OnCaptionFillChanged?.Invoke(isCaptionBeenFill);
        }
    }

    public void OnSubmit()
    {
        Debug.Log("Caption submitted: " + captionInput.text);
        ResetCaption();
    }

    public void ResetCaption()
    {
        captionInput.text = "";
        isCaptionBeenFill = false;
        OnCaptionFillChanged?.Invoke(isCaptionBeenFill);
    }
}
