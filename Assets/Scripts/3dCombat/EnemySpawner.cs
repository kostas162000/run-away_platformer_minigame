using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    [Header("Spawning Settings")]
    public GameObject enemyPrefab;       // The enemy prefab to spawn
    public Transform[] spawnPoints;      // Array of spawn points
    public int maxEnemies = 10;          // Maximum enemies to spawn
    public float spawnIntervalMin = 0.5f; // Minimum delay between spawns
    public float spawnIntervalMax = 3f;  // Maximum delay between spawns
    public float spawnDuration = 20f;    // Total time window for spawning (in seconds)

    private int currentEnemyCount = 0;

    void Start()
    {
        StartCoroutine(SpawnEnemiesRandomly());
    }

    IEnumerator SpawnEnemiesRandomly()
    {
        float elapsedTime = 0f;

        while(elapsedTime < spawnDuration && currentEnemyCount < maxEnemies)
        {
            // Wait for a random duration between the defined min and max.
            float waitTime = Random.Range(spawnIntervalMin, spawnIntervalMax);
            yield return new WaitForSeconds(waitTime);
            elapsedTime += waitTime;

            // Select a random spawn point.
            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
            currentEnemyCount++;
        }
    }

    // This method can be called by an enemy when it dies.
    public void OnEnemyDeath()
    {
        currentEnemyCount--;
    }
}
