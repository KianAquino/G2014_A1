using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField] private MusicType _music;

    private void Start()
    {
        AudioSystem.Instance.PlayMusic(_music);
    }
}
