using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
    [Header("Config Audio")]
    public AudioMixer audioMixer;
    public Slider MasterVolume;
    public bool isMusicMuted;
    public bool isSoundMuted;

    private const float MUTED = -80f;
    private const float UNMUTED = 0f;

    public void UpdateMasterVolume(float volumeValue)
    {
        audioMixer.SetFloat("MasterVolume", volumeValue);
    }

    public void ToggleMusic()
    {
        audioMixer.GetFloat("MusicVolume", out float currentVolume);

        isMusicMuted = currentVolume <= MUTED + 1f;

        audioMixer.SetFloat("MusicVolume", isMusicMuted ? UNMUTED : MUTED);
    }

    public void ToggleSounds()
    {
        audioMixer.GetFloat("SoundEffectsVolume", out float currentVolume);

        isSoundMuted  = currentVolume <= MUTED + 1f;

        audioMixer.SetFloat("SoundEffectsVolume", isSoundMuted ? UNMUTED : MUTED);
    }
}
