using UnityEngine;

public enum MusicType
{
    MAIN_MENU,
    GAME
}
public enum SFXType
{
    CLICK,
    EAT,
    HURT,
    BONNIE_ENTER,
    BONNIE_EXIT,
    MASK_ON,
    MASK_OFF
}

[ExecuteInEditMode]
public class AudioSystem : Singleton<AudioSystem>
{
    [SerializeField] private SoundList[] _musicList;
    [SerializeField] private SoundList[] _SFXList;

    private AudioSource _musicSource;
    private AudioSource _SFXSource;

    protected override void Awake()
    {
        base.Awake();

        if (Application.isPlaying )
        {
            _musicSource = gameObject.AddComponent<AudioSource>();
            _SFXSource = gameObject.AddComponent<AudioSource>();

            _musicSource.loop = true;
        }
    }

    public void PlayMusic(MusicType sound, float volume = 0.5f)
    {
        AudioClip[] clips = _musicList[(int)sound].Sounds;
        AudioClip clip = clips[Random.Range(0, clips.Length)];

        _musicSource.clip = clip;
        _musicSource.volume = volume;
        _musicSource.Play();
    }

    public void PlaySFX(SFXType sound, float volume = 1f)
    {
        AudioClip[] clips = _SFXList[(int)sound].Sounds;
        AudioClip clip = clips[Random.Range(0, clips.Length)];

        _SFXSource.PlayOneShot(clip, volume);
    }

#if UNITY_EDITOR
    private void OnEnable()
    {
        string[] names;

        // Music List
        names = System.Enum.GetNames(typeof(MusicType));
        System.Array.Resize(ref _musicList, names.Length);
        for (int i = 0; i < _musicList.Length; i++)
            _musicList[i].Name = names[i];
        
        // SFX List
        names = System.Enum.GetNames(typeof(SFXType));
        System.Array.Resize(ref _SFXList, names.Length);
        for (int i = 0; i < _SFXList.Length; i++)
            _SFXList[i].Name = names[i];
    }
#endif
}

[System.Serializable]
public struct SoundList
{
    [HideInInspector] public string Name;
    [SerializeField] private AudioClip[] _sounds;

    public AudioClip[] Sounds { get { return _sounds; } }
}