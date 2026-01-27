using UnityEngine;
using System.Collections.Generic;

public class TerrainGen : MonoBehaviour
{
    [Header("Spawn Settings")]
    public GameObject treePrefab;
    public int treeCount = 15;
    public float spawnRadius = 10f;
    public float minSpacing = 2.5f;
    public LayerMask terrainLayer;
    public LayerMask vegetationLayer;

    [Header("Terrain Settings")]
    public float waterHeight = 0f;
    public float shorelineBuffer = 0.1f;

    [Header("Raycast")]
    public float raycastHeight = 100f;

    private List<Vector3> spawnedPositions = new List<Vector3>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnTrees();
    }

    void SpawnTrees()
    {
        int spawned = 0;
        int attempts = 0;

        while (spawned < treeCount && attempts < 500)
        {
            attempts++;

            Vector3 randomPos = new Vector3
            (
                Random.Range(-spawnRadius, spawnRadius), 
                raycastHeight, 
                Random.Range(-spawnRadius, spawnRadius)
            );

            if (Physics.Raycast(randomPos, Vector3.down, out RaycastHit hit, raycastHeight * 2f, terrainLayer)) 
            {
                Vector3 spawnPoint = hit.point;

                float heightAboveWater = spawnPoint.y - waterHeight;

                if (heightAboveWater < shorelineBuffer)
                {
                    continue;
                }

                Collider[] overlaps = Physics.OverlapSphere
                (
                    spawnPoint,
                    minSpacing,
                    vegetationLayer
                );

                if (overlaps.Length == 0)
                {
                    Instantiate
                    (
                        treePrefab, 
                        spawnPoint, 
                        Quaternion.Euler(-90f, 0f, 0f)
                    );
                    spawnedPositions.Add(spawnPoint);
                    spawned++;
                }
            }
        }

        if (spawned < treeCount)
        {
            Debug.LogWarning($"Only spawned {spawned}/{treeCount} trees. Increase area or reduce spacing.");
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        foreach (var pos in spawnedPositions)
        {
            Gizmos.DrawWireSphere(pos, minSpacing);
        }
    }
}
