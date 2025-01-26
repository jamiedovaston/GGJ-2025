using UnityEngine;
using System;
using UnityEditor;
using Unity.VisualScripting;

public enum SoundType
{
    BUBBLESHOOT,
    BUBBLEPOP,
    BUBBLEHIT,
    CHANGEMAG,
    PUMPGUN,
    FOOTSTEP,
    JUMP,
    LAND,
    FROG,
    MENUMUSIC,
    LEVELMUSIC
}

[RequireComponent(typeof(AudioSource)), ExecuteInEditMode]
public class SoundManager : MonoBehaviour
{
    [SerializeField] private SoundList[] soundList;
    private static SoundManager instance;
    private AudioSource audioSource;
    private AudioSource musicSource;

    #region setup
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }

        AudioSource[] sources = GetComponents<AudioSource>();
        audioSource = sources[0];
        // ensure second source available
        if (sources.Length < 2)
        {
            musicSource = gameObject.AddComponent<AudioSource>();
        }
        else
        {
            musicSource = sources[1];
        }
        musicSource.loop = true;
        AudioClip[] musicClips = instance.soundList[(int)SoundType.MENUMUSIC].Sounds;
        if (musicClips.Length < 0)
        {
            musicSource.clip = musicClips[UnityEngine.Random.Range(0,musicClips.Length)];
        }
    }

    public void Start()
    {
    }

#if UNITY_EDITOR
    private void OnEnable()
    {
        string[] names = Enum.GetNames(typeof(SoundType));
        Array.Resize(ref soundList, names.Length);
        for (int i = 0; i < soundList.Length; i++)
        {
            soundList[i].name = names[i];
        }
    }
#endif

    #endregion

    #region SFX
    public static void PlaySound(SoundType sound, float volume = 1)
    {
        AudioClip[] clips = instance.soundList[(int)sound].Sounds;
        if (instance.audioSource != null)
        {
            instance.audioSource.PlayOneShot(clips[UnityEngine.Random.Range(0, clips.Length)], volume);
        }
    }
    #endregion

    #region music
    public static void StartMusic(SoundType sound, float volume = 1)
    {
        instance.musicSource.Play();
    }

    public static void StopMusic()
    {
        instance.musicSource.Stop();
    }
    #endregion

}

[Serializable]
public struct SoundList
{
    [HideInInspector] public string name;
    public AudioClip[] Sounds { get => sounds; }
    [SerializeField] private AudioClip[] sounds;
}