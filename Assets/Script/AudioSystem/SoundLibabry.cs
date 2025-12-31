using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct SoundFX
{
    public string groupID;
    public AudioClip[] clipSoundFXs;
}

public class SoundLibabry : MonoBehaviour
{
    public SoundFX[] soundFXs;

    public AudioClip GetClipByGroupID(string group)
    {
        foreach (var soundFX in soundFXs)
        {
            if (soundFX.groupID == group)
            {
                return soundFX.clipSoundFXs[Random.Range(0, soundFX.clipSoundFXs.Length)];
            }
        }

        Debug.Log($"there are no sound library with {group}");
        return null;
    }

}
