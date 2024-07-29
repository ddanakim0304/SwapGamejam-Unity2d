using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellSpawner : MonoBehaviour
{
    public GameObject[] shellPrefabs; 
    public Transform[] spawnPoints; // Array of spawn points
    private float elapsedTime = 0f; // Timer to track total elapsed time
    private bool isBossSpawned = false; // Flag to check if the boss has spawned
    
    public float spawnTime = 2f; // Time between each shell spawn

    void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime >= spawnTime)
        {
            SpawnSaws(); //
            elapsedTime = 0f;
        }
    }

    public void StartTimer()
    {
        elapsedTime = 0f;
    }

    public void SpawnSaws()
    {
        int randomPrefabIndex = Random.Range(0, shellPrefabs.Length); // Get a random shell prefab
        int randomSpawnPointIndex = Random.Range(0, spawnPoints.Length); // Get a random spawn point

        Instantiate(shellPrefabs[randomPrefabIndex], spawnPoints[randomSpawnPointIndex].position, Quaternion.identity); // Instantiate the shell at the spawn point
    }
}