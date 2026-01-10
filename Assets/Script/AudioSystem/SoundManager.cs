using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [Header("Reference")]
    [SerializeField] private SoundLibabry _soundEffectlibrary;
    [SerializeField] private AudioSource _soundSource;
    [SerializeField] private AudioSource _loopSoundEffectSource;
    [SerializeField] private AudioSource _walkingSoundEffectSource;

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
        _soundSource.PlayOneShot(_soundEffectlibrary.GetClipByGroupID(soundName));
    }

    public void PlayLoopSoundEffect(string soundName)
    {
        AudioClip clip = _soundEffectlibrary.GetClipByGroupID(soundName);
        Debug.Log(clip.name);
 
        _loopSoundEffectSource.clip = clip;
        _loopSoundEffectSource.loop = true;
        _loopSoundEffectSource.Play();
    }

    public void StopLoopSoundEffect()
    {
        _loopSoundEffectSource.Stop();
        //_loopSoundEffectSource.clip = null;
        _loopSoundEffectSource.loop = false;
    }

    public void PlayWalkingSoundEffect(string soundName)
    {
        AudioClip clip = _soundEffectlibrary.GetClipByGroupID(soundName);
        Debug.Log(clip.name);

        _walkingSoundEffectSource.clip = clip;
        _walkingSoundEffectSource.loop = true;
        _walkingSoundEffectSource.Play();
    }

    public void StopWalkingSoundEffect()
    {
        _walkingSoundEffectSource.Stop();
        _walkingSoundEffectSource.loop = false;
    }

    public void StopAllSoundFX()
    {
        _soundSource.Stop();
    }

    public bool GetIsLoopSoundEffect()
    {
        return _soundSource.isPlaying;
    }
}
