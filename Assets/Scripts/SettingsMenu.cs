using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public AudioManager audioManager;
    public Slider bgmSlider;
    public Slider sfxSlider;
    public Text bgmValueText;
    public Text sfxValueText;

    void Start()
    {
        // スライダーの初期値をPlayerPrefsから読み込む
        float bgmVolume = PlayerPrefs.GetFloat("BGM_VOLUME", 1.0f);
        float sfxVolume = PlayerPrefs.GetFloat("SFX_VOLUME", 1.0f);

        bgmSlider.value = bgmVolume;
        sfxSlider.value = sfxVolume;

        // スライダーのイベントリスナー追加
        bgmSlider.onValueChanged.AddListener(SetBgmVolume);
        sfxSlider.onValueChanged.AddListener(SetSfxVolume);

        // 初期の値を表示
        bgmValueText.text = (bgmVolume * 100).ToString("0");
        sfxValueText.text = (sfxVolume * 100).ToString("0");
    }

    public void SetBgmVolume(float volume)
    {
        audioManager.SetBgmVolume(volume);
        bgmValueText.text = (volume * 100).ToString("0");
    }

    public void SetSfxVolume(float volume)
    {
        audioManager.SetSfxVolume(volume);
        sfxValueText.text = (volume * 100).ToString("0");
    }
}
