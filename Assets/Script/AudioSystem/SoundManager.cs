using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [Header("Reference")]
    [SerializeField] private SoundLibabry _soundFXlibrary;
    [SerializeField] private AudioSource _soundSource;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            DestroyImmediate(gameObject);
        }
    }

    public void PlaySoundFXOneClip(string soundName)
    {
        _soundSource.PlayOneShot(_soundFXlibrary.GetClipByGroupID(soundName));
    }

    public void StopAllSoundFX()
    {
        _soundSource.Stop();
    }

}
