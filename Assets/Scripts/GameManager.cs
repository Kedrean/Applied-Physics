using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int enemyCount;

    private void Awake()
    {
        Instance = this;
    }

    public void EnemyKilled()
    {
        enemyCount--;

        if (enemyCount <= 0)
            GameOver();
    }

    void GameOver()
    {
        StartCoroutine(GameOverDelay());
    }

    IEnumerator GameOverDelay()
    {
        yield return new WaitForSecondsRealtime(5f);

        Debug.Log("You Win!");
        Time.timeScale = 0f;
    }
}
