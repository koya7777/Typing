using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource bgmSource;
    public AudioSource sfxSource;
    public AudioClip bgmClip;
    public AudioClip correctSfx;
    public AudioClip incorrectSfx;

    private const string BgmVolumeKey = "BGM_VOLUME";
    private const string SfxVolumeKey = "SFX_VOLUME";

    void Start()
    {
        // BGMÇÃçƒê∂
        bgmSource.clip = bgmClip;
        bgmSource.loop = true;
        bgmSource.Play();

        // âπó ê›íËÇÃì«Ç›çûÇ›
        float bgmVolume = PlayerPrefs.GetFloat(BgmVolumeKey, 1.0f);
        float sfxVolume = PlayerPrefs.GetFloat(SfxVolumeKey, 1.0f);
        SetBgmVolume(bgmVolume);
        SetSfxVolume(sfxVolume);
    }

    public void PlayCorrectSfx()
    {
        sfxSource.PlayOneShot(correctSfx);
    }

    public void PlayIncorrectSfx()
    {
        sfxSource.PlayOneShot(incorrectSfx);
    }

    public void StopBgm()
    {
        bgmSource.Stop();
    }

    public void SetBgmVolume(float volume)
    {
        bgmSource.volume = volume;
        PlayerPrefs.SetFloat(BgmVolumeKey, volume);
        PlayerPrefs.Save();
    }

    public void SetSfxVolume(float volume)
    {
        sfxSource.volume = volume;
        PlayerPrefs.SetFloat(SfxVolumeKey, volume);
        PlayerPrefs.Save();
    }
}
