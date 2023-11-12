using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource backgroundMusicSource;
    public AudioSource soundEffectsSource;
    public List<AudioClip> soundEffectClips;

    [Range(0, 100)]
    public float backgroundMusicVolume = 100;
    [Range(0, 100)]
    public float soundEffectsVolume = 100;
    public AudioClip backgroundMusicClip;
    private bool isSoundEffectPlaying = false;
    private Queue<int> soundEffectQueue = new Queue<int>();

    private void Awake()
    {
        // Ensure there is only one instance of AudioManager in the scene
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Initialize the audio sources and set their initial volumes
        backgroundMusicSource = gameObject.AddComponent<AudioSource>();
        soundEffectsSource = gameObject.AddComponent<AudioSource>();

        backgroundMusicSource.volume = backgroundMusicVolume / 100f;
        soundEffectsSource.volume = soundEffectsVolume / 100f;

        PlayBackgroundMusic(backgroundMusicClip);

    }

    public void PlayBackgroundMusic(AudioClip musicClip)
    {
        backgroundMusicSource.clip = musicClip;
        backgroundMusicSource.loop = true;
        backgroundMusicSource.Play();
    }

    public void PlaySoundEffect(int soundEffectIndex)
    {
        if (soundEffectIndex >= 0 && soundEffectIndex < soundEffectClips.Count)
        {
            soundEffectQueue.Enqueue(soundEffectIndex);

            if (!isSoundEffectPlaying)
            {
                PlayNextSoundEffect();
            }
        }
    }

    private void PlayNextSoundEffect()
    {
        if (soundEffectQueue.Count > 0)
        {
            int nextSoundEffectIndex = soundEffectQueue.Dequeue();
            isSoundEffectPlaying = true;
            soundEffectsSource.PlayOneShot(soundEffectClips[nextSoundEffectIndex]);
            StartCoroutine(WaitForSoundEffectToFinish(nextSoundEffectIndex));
        }
    }

    private IEnumerator WaitForSoundEffectToFinish(int soundEffectIndex)
    {
        yield return new WaitForSeconds(soundEffectClips[soundEffectIndex].length);
        isSoundEffectPlaying = false;

        PlayNextSoundEffect();
    }

    public void SetBackgroundMusicVolume(float volume)
    {
        backgroundMusicVolume = Mathf.Clamp(volume, 0, 100);
        backgroundMusicSource.volume = backgroundMusicVolume / 100f;
    }

    public void SetSoundEffectsVolume(float volume)
    {
        soundEffectsVolume = Mathf.Clamp(volume, 0, 100);
        soundEffectsSource.volume = soundEffectsVolume / 100f;
    }

    public bool EffectPlaying => isSoundEffectPlaying;
}
