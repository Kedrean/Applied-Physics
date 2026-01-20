using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public int currentScore;
    public int highScore;

    void Awake()
    {
        if (Instance == null)
            Instance = this;

        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }

    public void AddScore(int amount)
    {
        currentScore += amount;
    }

    public void EndRound()
    {
        if (currentScore > highScore)
        {
            highScore = currentScore;
            PlayerPrefs.SetInt("HighScore", highScore);
        }
    }
}
