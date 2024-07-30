using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellSpawner : MonoBehaviour
{
    public GameObject[] shellPrefabs; 
    public Transform[] spawnPoints; // Array of spawn points
    private float elapsedTime = 0f; // Timer to track total elapsed time
    public float spawnTime = 2f; // Time between each shell spawn

    void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime >= spawnTime)
        {
            SpawnSaws(); // Spawn two shells
            elapsedTime = 0f;
        }
    }

    public void StartTimer()
    {
        elapsedTime = 0f;
    }

    public void SpawnSaws()
    {
        for (int i = 0; i < 2; i++) // Loop to spawn two shells
        {
            int randomPrefabIndex = Random.Range(0, shellPrefabs.Length); // Get a random shell prefab
            int randomSpawnPointIndex = Random.Range(0, spawnPoints.Length); // Get a random spawn point

            Instantiate(shellPrefabs[randomPrefabIndex], spawnPoints[randomSpawnPointIndex].position, Quaternion.identity); // Instantiate the shell at the spawn point
        }
}
}