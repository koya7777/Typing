using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject settingsMenu; // 設定画面のCanvas

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
        SceneManager.LoadScene("TitleScene"); // タイトルシーンの名前を指定
    }
}
