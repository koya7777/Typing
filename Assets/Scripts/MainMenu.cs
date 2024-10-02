using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject settingsMenu; // �ݒ��ʂ�Canvas

    public void OpenSettingsMenu()
    {
        settingsMenu.SetActive(true);
    }

    public void CloseSettingsMenu()
    {
        settingsMenu.SetActive(false);
    }

    public void ReturnToTitle()
    {
        SceneManager.LoadScene("TitleScene"); // �^�C�g���V�[���̖��O���w��
    }
}
