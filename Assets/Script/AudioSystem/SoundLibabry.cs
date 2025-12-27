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

    public AudioClip GetClipByGroupID(string groupID)
    {
        foreach (var soundFX in soundFXs)
        {
            if (soundFX.groupID == groupID)
            {
                return soundFX.clipSoundFXs[Random.Range(0, soundFXs.Length)];
            }
        }

        return null;
    }

}
