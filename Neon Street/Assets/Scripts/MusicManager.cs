using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance;

    [Header("Audio Background Settings")]
    public AudioClip backgroundMusic;
    [Range(0f, 1f)] public float musicVolume = 0.5f;

    [Header("Audio SFX Settings")]
    public AudioClip jumpClip;
    public AudioClip deathClip;
    public AudioClip scoreClip;
    [Range(0f, 1f)] public float sfxVolume = 0.7f;

    private AudioSource musicSource;
    private AudioSource sfxSource;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        // Música
        musicSource = gameObject.AddComponent<AudioSource>();
        musicSource.clip = backgroundMusic;
        musicSource.loop = true;
        musicSource.volume = musicVolume;
        musicSource.playOnAwake = false;

        // SFX
        sfxSource = gameObject.AddComponent<AudioSource>();
        sfxSource.loop = false;
        sfxSource.playOnAwake = false;
        sfxSource.volume = sfxVolume;

        PlayMusic();
    }

    // ---------- MÚSICA ----------
    public void PlayMusic()
    {
        if (!musicSource.isPlaying)
            musicSource.Play();
    }

    public void StopMusic()
    {
        if (musicSource.isPlaying)
            musicSource.Stop();
    }

    public void SetMusicVolume(float newVolume)
    {
        musicVolume = Mathf.Clamp01(newVolume);
        musicSource.volume = musicVolume;
    }

    public void ChangeMusic(AudioClip newClip)
    {
        musicSource.Stop();
        musicSource.clip = newClip;
        musicSource.Play();
    }

    // ---------- SFX ----------
    public void PlaySFX(AudioClip clip)
    {
        if (clip != null)
            sfxSource.PlayOneShot(clip, sfxVolume);
    }

    public void SetSFXVolume(float newVolume)
    {
        sfxVolume = Mathf.Clamp01(newVolume);
        sfxSource.volume = sfxVolume;
    }


    public void PlayJumpSFX()
    {
        PlaySFX(jumpClip);
    }

    public void PlayDeathSFX()
    {
        PlaySFX(deathClip);
    }

    public void PlayScoreSFX()
    {
        PlaySFX(scoreClip);
    }
}
