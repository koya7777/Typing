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

    // �Q�[���V�[�������[�h���郁�\�b�h
    public void LoadGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }

    // �^�C�g���V�[�������[�h���郁�\�b�h
    public void LoadTitleScene()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
