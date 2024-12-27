using UnityEngine;
using System.Collections;
using Platformer.Mechanics;

public class TriggerSpawnEnemy : MonoBehaviour
{
    [Tooltip("The enemy prefab to spawn when triggered.")]
    public GameObject enemyPrefab;

    [Tooltip("The position where the enemy should be spawned.")]
    public Transform spawnPoint;

    [Tooltip("The number of enemies to spawn.")]
    public int numberOfEnemies = 1;

    [Tooltip("The delay between spawning each enemy (in seconds).")]
    public float spawnDelay = 1f;

    [Tooltip("The lifetime of each spawned enemy (in seconds).")]
    public float enemyLifetime = 5f;

    void OnTriggerEnter2D(Collider2D other)
    {
        var rb = other.attachedRigidbody;
        if (rb == null) return;

        var player = rb.GetComponent<PlayerController>();
        if (player != null && enemyPrefab != null && spawnPoint != null)
        {
            // Start spawning enemies with the specified delay
            StartCoroutine(SpawnEnemies());
        }
        else
        {
            Debug.LogWarning("TriggerSpawnEnemy: Missing reference to enemyPrefab or spawnPoint.");
        }
    }

    private IEnumerator SpawnEnemies()
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            // Instantiate the enemy at the specified spawn point
            var enemy = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);

            // Destroy the enemy after the specified lifetime
            Destroy(enemy, enemyLifetime);

            // Wait for the spawn delay before spawning the next enemy
            yield return new WaitForSeconds(spawnDelay);
        }
    }
}
