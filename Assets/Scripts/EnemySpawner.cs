using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int spawnCount = 10;
    public float spawnRadius = 30f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        Vector3 randomPos = new Vector3
        (
            Random.Range(-spawnRadius, spawnRadius),
            50f,
            Random.Range(-spawnRadius, spawnRadius)
        );

        if (Physics.Raycast(randomPos, Vector3.down, out RaycastHit hit, 100f))
        {
            Instantiate(enemyPrefab, hit.point, Quaternion.identity);
        }
    }
}
