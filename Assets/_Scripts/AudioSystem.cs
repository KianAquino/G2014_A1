using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SFXType
{
    CLICK
}

public class AudioSystem : Singleton<AudioSystem>
{
    [SerializeField] private SoundList[] _SFXList;

    private AudioSource _musicSource;
    private AudioSource _SFXSource;

    private void Start()
    {
        _musicSource = gameObject.AddComponent<AudioSource>();
        _SFXSource = gameObject.AddComponent<AudioSource>();
    }

    public void PlaySFX(SFXType sound, float volume = 1)
    {
        Debug.Log("Click SFX Played");
    }
}

[System.Serializable]
public struct SoundList
{
    [SerializeField] private AudioClip[] _sounds;
}