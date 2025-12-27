using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct MusicTrack
{
    public string nameTrack;
    public AudioClip musicTrack;
}


public class MusicLibabry : MonoBehaviour
{
    public MusicTrack[] tracks;

    public AudioClip GetClipByName(string nameTrack)
    {
        foreach (MusicTrack track in tracks)
        {
            if (track.nameTrack == nameTrack)
            {
                return track.musicTrack;
            }
        }
        return null;
    }
}
