using UnityEngine;
using TMPro;

public class RoundManager : MonoBehaviour
{
    public float roundTime = 30f;
    public GameObject endPanel;
    public TextMeshProUGUI endText;

    private float timer;
    private bool roundEnded;

    void Start()
    {
        timer = roundTime;
        endPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    void Update()
    {
        if (roundEnded) return;

        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            EndRound();
        }
    }

    void EndRound()
    {
        roundEnded = true;
        ScoreManager.Instance.EndRound();

        endPanel.SetActive(true);
        endText.text =
            "<b>ROUND OVER</b>\n\n" +
            "Score: " + ScoreManager.Instance.currentScore + "\n" +
            "High Score: " + ScoreManager.Instance.highScore;

        // Unlock cursor for UI
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        Time.timeScale = 0f;
    }
}
