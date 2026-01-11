using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ToggleAudioUI : MonoBehaviour
{
    public TextMeshProUGUI toggleAudio;
    private bool isMuted;

    public void ChangeToggleAudioUI()
    {
        if (!isMuted)
        {
            isMuted = true;
            toggleAudio.text = "Off";
        }
        else
        {
            isMuted = false;
            toggleAudio.text = "On";
        }
    }
}
