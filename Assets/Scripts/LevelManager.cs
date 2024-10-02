using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }
    public int SelectedLevel { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetLevel(int level)
    {
        Debug.Log("Setting level to: " + level);
        SelectedLevel = level;
    }

    public bool HasNextLevel(int totalLevels)
    {
        bool hasNext = SelectedLevel < totalLevels - 1;
        Debug.Log("Has next level: " + hasNext);
        return hasNext;
    }
}
