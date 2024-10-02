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
        // �X���C�_�[�̏����l��PlayerPrefs����ǂݍ���
        float bgmVolume = PlayerPrefs.GetFloat("BGM_VOLUME", 1.0f);
        float sfxVolume = PlayerPrefs.GetFloat("SFX_VOLUME", 1.0f);

        bgmSlider.value = bgmVolume;
        sfxSlider.value = sfxVolume;

        // �X���C�_�[�̃C�x���g���X�i�[�ǉ�
        bgmSlider.onValueChanged.AddListener(SetBgmVolume);
        sfxSlider.onValueChanged.AddListener(SetSfxVolume);

        // �����̒l��\��
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
