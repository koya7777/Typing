using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TypingGameController : MonoBehaviour
{
    public Text hiraganaWordDisplayText;
    public Text romajiWordDisplayText;
    public InputField inputField;
    public Text scoreText;
    public Text timerText;

    public GameObject gameOverScreen;
    public GameObject gameClearScreen;
    public Text gameOverScoreText; // �Q�[���I�[�o�[�X�R�A�\���p�e�L�X�g
    public Text gameClearMessageText; // �Q�[���N���A���b�Z�[�W�\���p�e�L�X�g
    public AudioManager audioManager;

    public WordList[] levelWordLists; // ���x�����Ƃ̒P�ꃊ�X�g
    private string[] hiraganaWords;
    private string[] romajiWords;
    private string currentHiraganaWord;
    private string currentRomajiWord;
    private int score;
    private float timeRemaining = 60f;
    private int currentLevel; // ���݂̃��x��
    private int currentWordIndex = 0; // ���݂̒P��C���f�b�N�X
    private int correctLength = 0; // ���������͂��ꂽ������

    void Start()
    {
        currentLevel = LevelManager.Instance.SelectedLevel;
        if (currentLevel >= 0 && currentLevel < levelWordLists.Length)
        {
            hiraganaWords = levelWordLists[currentLevel].hiraganaWords;
            romajiWords = levelWordLists[currentLevel].romajiWords;
        }
        else
        {
            Debug.LogError("Invalid level selected");
        }

        inputField.onValueChanged.AddListener(CheckInput);
        SetNewWord();
        score = 0;
        UpdateScoreText();
        inputField.ActivateInputField(); // �Q�[���J�n����InputField���A�N�e�B�u�ɂ���
    }

    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            UpdateTimerText();
        }
        else
        {
            EndGame();
        }
    }

    void CheckInput(string userInput)
    {
        if (userInput.Length > correctLength)
        {
            string nextChar = userInput.Substring(correctLength, 1);

            if (currentRomajiWord[correctLength].ToString().Equals(nextChar, System.StringComparison.OrdinalIgnoreCase))
            {
                correctLength++;
                UpdateRomajiDisplay(correctLength);
                audioManager.PlayCorrectSfx(); // �����̌��ʉ����Đ�

                if (correctLength == currentRomajiWord.Length)
                {
                    score++;
                    UpdateScoreText();
                    inputField.text = string.Empty;
                    correctLength = 0;
                    currentWordIndex++;

                    if (currentWordIndex >= hiraganaWords.Length)
                    {
                        // ���ׂĂ̒P��ɐ��������ꍇ
                        GameClear();
                    }
                    else
                    {
                        SetNewWord();
                        inputField.ActivateInputField(); // �V�����P�ꂪ�\�����ꂽ�Ƃ���InputField���A�N�e�B�u�ɂ���
                    }
                }
            }
            else
            {
                inputField.text = userInput.Substring(0, correctLength);
                audioManager.PlayIncorrectSfx(); // �s�����̌��ʉ����Đ�
                inputField.ActivateInputField(); // �s���ȓ��͂��������ꍇ��InputField���A�N�e�B�u�ɂ���
            }
        }
    }

    void SetNewWord()
    {
        if (hiraganaWords.Length > 0 && romajiWords.Length > 0)
        {
            currentHiraganaWord = hiraganaWords[currentWordIndex];
            currentRomajiWord = romajiWords[currentWordIndex];
            hiraganaWordDisplayText.text = currentHiraganaWord;
            UpdateRomajiDisplay(0);
        }
    }

    void UpdateRomajiDisplay(int correctLength)
    {
        string correctPart = "<color=green>" + currentRomajiWord.Substring(0, correctLength) + "</color>";
        string remainingPart = currentRomajiWord.Substring(correctLength);
        romajiWordDisplayText.text = correctPart + remainingPart;
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    void UpdateTimerText()
    {
        timerText.text = "Time: " + Mathf.Round(timeRemaining).ToString();
    }

    void EndGame()
    {
        hiraganaWordDisplayText.text = "Game Over!";
        romajiWordDisplayText.text = "";
        inputField.interactable = false;
        audioManager.StopBgm(); // �Q�[���I�[�o�[����BGM���~
        gameOverScoreText.text = "Your score is: " + score.ToString() + " points"; // �X�R�A�̕\��
        gameOverScreen.SetActive(true); // �Q�[���I�[�o�[��ʂ�\��
    }

    void GameClear()
    {
        inputField.interactable = false;
        audioManager.StopBgm(); // �Q�[���N���A����BGM���~

        if (LevelManager.Instance.HasNextLevel(levelWordLists.Length))
        {
            gameClearMessageText.text = "Congratulations! Moving to the next stage.";
            Invoke("LoadNextLevel", 5f); // 5�b��Ɏ��̃��x�������[�h
        }
        else
        {
            gameClearMessageText.text = "Congratulations! You have cleared the game!";
        }

        gameClearScreen.SetActive(true); // �Q�[���N���A��ʂ�\��
    }

    void LoadNextLevel()
    {
        Debug.Log("Loading next level...");
        if (LevelManager.Instance.HasNextLevel(levelWordLists.Length))
        {
            Debug.Log("Next level is available.");
            LevelManager.Instance.SetLevel(currentLevel + 1);
            gameClearScreen.SetActive(false); // ���̃��x�������[�h����O�ɃN���A��ʂ��\���ɂ���
            SceneManager.LoadScene("GameScene"); // �Q�[���V�[���̖��O���w��
        }
        else
        {
            Debug.Log("No next level available.");
        }
    }
}
