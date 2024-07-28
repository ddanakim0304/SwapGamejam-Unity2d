using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public GameObject[] enemiesPrefabs; // Array of enemy prefabs
    public Transform[] spawnPoints; // Array of spawn points
    public float spawnRate = 2f; // Time between spawns
    private float timer = 0f; // Timer to track time between spawns
    private float difficultyTimer = 0f; // Timer to track difficulty progression
    public float difficultyIncreaseInterval = 10f; // Time interval to increase difficulty
    private float elapsedTime = 0f; // Timer to track total elapsed time
    public float maxSpawnTime = 60f; // Maximum time to spawn enemies

    // Update is called once per frame
    void Update()
    {
        // Update the total elapsed time
        elapsedTime += Time.deltaTime;

        // Stop spawning after maxSpawnTime
        if (elapsedTime >= maxSpawnTime)
        {
            return;
        }

        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            randomSpawn();
            timer = 0;
        }

        // Update the difficulty timer
        difficultyTimer += Time.deltaTime;
    }

    void randomSpawn()
    {
        // Determine the maximum enemy index based on the difficulty timer
        int maxEnemyIndex = Mathf.Min((int)(difficultyTimer / difficultyIncreaseInterval), enemiesPrefabs.Length - 1);

        // Get random enemy and spawn point
        int randEnemy = Random.Range(0, maxEnemyIndex + 1);
        int randSpawnPoint = Random.Range(0, spawnPoints.Length);

        // Instantiate the enemy at the selected spawn point
        Instantiate(enemiesPrefabs[randEnemy], spawnPoints[randSpawnPoint].position, spawnPoints[randSpawnPoint].rotation);
    }
}