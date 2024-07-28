using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawSpawner : MonoBehaviour
{
    public GameObject[] garbagePrefabs;
    public Transform spawnPoint;
    public float initialSpawnRate = 3f; // Initial spawn rate in seconds
    public float maxSpawnRate = 1f; // Maximum spawn rate in seconds
    public float spawnRateIncreaseInterval = 5f; // Interval to increase spawn rate in seconds
    public float spawnRateIncreaseAmount = 0.2f; // Amount to decrease spawn rate
    private float currentSpawnRate;
    private float spawnTimer = 0f;
    private float increaseTimer = 0f;

    void Start()
    {
        currentSpawnRate = initialSpawnRate;
    }

    void Update()
    {
        // Update the spawn timer
        spawnTimer += Time.deltaTime;
        increaseTimer += Time.deltaTime;

        // Check if it's time to spawn garbage
        if (spawnTimer >= currentSpawnRate)
        {
            SpawnGarbage();
            spawnTimer = 0f;
        }

        // Check if it's time to increase the spawn rate
        if (increaseTimer >= spawnRateIncreaseInterval)
        {
            IncreaseSpawnRate();
            increaseTimer = 0f;
        }
    }

    void SpawnGarbage()
    {
        // Select a random prefab from the array
        int prefabIndex = Random.Range(0, garbagePrefabs.Length);
        GameObject selectedPrefab = garbagePrefabs[prefabIndex];
        // Instantiate the selected prefab at the spawn point
        Instantiate(selectedPrefab, spawnPoint.position, spawnPoint.rotation);
    }

    void IncreaseSpawnRate()
    {
        // Decrease the spawn rate, ensuring it doesn't go below the maximum spawn rate
        currentSpawnRate = Mathf.Max(currentSpawnRate - spawnRateIncreaseAmount, maxSpawnRate);
    }
}