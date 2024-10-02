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
    public Text gameOverScoreText; // ゲームオーバースコア表示用テキスト
    public Text gameClearMessageText; // ゲームクリアメッセージ表示用テキスト
    public AudioManager audioManager;

    public WordList[] levelWordLists; // レベルごとの単語リスト
    private string[] hiraganaWords;
    private string[] romajiWords;
    private string currentHiraganaWord;
    private string currentRomajiWord;
    private int score;
    private float timeRemaining = 60f;
    private int currentLevel; // 現在のレベル
    private int currentWordIndex = 0; // 現在の単語インデックス
    private int correctLength = 0; // 正しく入力された文字数

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
        inputField.ActivateInputField(); // ゲーム開始時にInputFieldをアクティブにする
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
                audioManager.PlayCorrectSfx(); // 正解の効果音を再生

                if (correctLength == currentRomajiWord.Length)
                {
                    score++;
                    UpdateScoreText();
                    inputField.text = string.Empty;
                    correctLength = 0;
                    currentWordIndex++;

                    if (currentWordIndex >= hiraganaWords.Length)
                    {
                        // すべての単語に正解した場合
                        GameClear();
                    }
                    else
                    {
                        SetNewWord();
                        inputField.ActivateInputField(); // 新しい単語が表示されたときにInputFieldをアクティブにする
                    }
                }
            }
            else
            {
                inputField.text = userInput.Substring(0, correctLength);
                audioManager.PlayIncorrectSfx(); // 不正解の効果音を再生
                inputField.ActivateInputField(); // 不正な入力があった場合にInputFieldをアクティブにする
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
        audioManager.StopBgm(); // ゲームオーバー時にBGMを停止
        gameOverScoreText.text = "Your score is: " + score.ToString() + " points"; // スコアの表示
        gameOverScreen.SetActive(true); // ゲームオーバー画面を表示
    }

    void GameClear()
    {
        inputField.interactable = false;
        audioManager.StopBgm(); // ゲームクリア時にBGMを停止

        if (LevelManager.Instance.HasNextLevel(levelWordLists.Length))
        {
            gameClearMessageText.text = "Congratulations! Moving to the next stage.";
            Invoke("LoadNextLevel", 5f); // 5秒後に次のレベルをロード
        }
        else
        {
            gameClearMessageText.text = "Congratulations! You have cleared the game!";
        }

        gameClearScreen.SetActive(true); // ゲームクリア画面を表示
    }

    void LoadNextLevel()
    {
        Debug.Log("Loading next level...");
        if (LevelManager.Instance.HasNextLevel(levelWordLists.Length))
        {
            Debug.Log("Next level is available.");
            LevelManager.Instance.SetLevel(currentLevel + 1);
            gameClearScreen.SetActive(false); // 次のレベルをロードする前にクリア画面を非表示にする
            SceneManager.LoadScene("GameScene"); // ゲームシーンの名前を指定
        }
        else
        {
            Debug.Log("No next level available.");
        }
    }
}
