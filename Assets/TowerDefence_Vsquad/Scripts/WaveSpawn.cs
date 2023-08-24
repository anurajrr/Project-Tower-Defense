using UnityEngine;
using System.Collections;

public class WaveSpawn : MonoBehaviour {

    public int WaveSize;             // Number of enemies in the wave
    public GameObject EnemyPrefab;   // The enemy prefab to spawn
    public float EnemyInterval;      // Time interval between spawning each enemy
    public Transform spawnPoint;     // The point where enemies are spawned
    public float startTime;          // Time delay before starting the wave
    public Transform[] WayPoints;    // Waypoints for the enemies to follow
    int enemyCount = 0;              // Counter for the spawned enemies

    void Start ()
    {
        // Start spawning enemies at a delayed interval
        InvokeRepeating("SpawnEnemy", startTime, EnemyInterval);
    }

    void Update()
    {
        // Check if all enemies in the wave are spawned
        if (enemyCount == WaveSize)
        {
            // Cancel the spawning schedule
            CancelInvoke("SpawnEnemy");
        }
    }

    // Function to spawn an enemy
    void SpawnEnemy()
    {
        enemyCount++; // Increment the enemy count
        // Instantiate an enemy at the spawn point with no rotation
        GameObject enemy = GameObject.Instantiate(EnemyPrefab, spawnPoint.position, Quaternion.identity) as GameObject;
        enemy.GetComponent<Enemy>().waypoints = WayPoints; // Set the enemy's waypoints for movement
    }
}
