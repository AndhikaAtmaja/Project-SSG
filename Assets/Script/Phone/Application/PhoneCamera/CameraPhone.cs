using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPhone : MonoBehaviour
{
    public static event Action OnCameraOpenned;

    private void OpenCamera()
    {
        OnCameraOpenned?.Invoke();
    }

    private void OnEnable()
    {
        if (this.gameObject.activeSelf)
            OpenCamera();
    }
}
