using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObstacleSpawner : MonoBehaviour
{
    [Header("References")]
    public GameObject enemyCarPrefab;
    public Transform spawnPoint;

    [Header("Customizable Lane Positions")]
    [Tooltip("X offsets relative to the SpawnPoint")]
    public float[] lanePositions = { -2f, 0f, 2f };

    [Header("Spawn Settings")]
    public bool randomizeLane = true;

    // Call this from your beat detection script
    private void Awake()
    {
        Store.validActiveBeatEvent += OnValidActiveBeat;
    }

    public void OnValidActiveBeat()
    {
        SpawnEnemy();
    }
    
    public void SpawnEnemy()
    {
        if (enemyCarPrefab == null || spawnPoint == null)
        {
            Debug.LogWarning("Enemy prefab or SpawnPoint is missing!");
            return;
        }

        if (lanePositions == null || lanePositions.Length == 0)
        {
            Debug.LogWarning("No lane positions configured!");
            return;
        }

        int laneIndex = Random.Range(0, lanePositions.Length);

        SpawnEnemyAtLane(laneIndex);
    }

    // Spawn at a specific lane if needed
    public void SpawnEnemyAtLane(int laneIndex)
    {
        if (enemyCarPrefab == null || spawnPoint == null)
            return;

        if (lanePositions == null ||
            laneIndex < 0 ||
            laneIndex >= lanePositions.Length)
        {
            Debug.LogWarning("Invalid lane index!");
            return;
        }

        Vector3 spawnPosition = spawnPoint.position;

        spawnPosition.x += lanePositions[laneIndex];

        Instantiate(
            enemyCarPrefab,
            spawnPosition,
            spawnPoint.rotation
        );
    }

    // Test spawning directly from the Inspector
    [ContextMenu("Test Spawn Enemy")]
    private void TestSpawnEnemy()
    {
        SpawnEnemy();
    }
}
