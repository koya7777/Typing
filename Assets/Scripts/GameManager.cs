using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    // ゲームシーンをロードするメソッド
    public void LoadGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }

    // タイトルシーンをロードするメソッド
    public void LoadTitleScene()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
