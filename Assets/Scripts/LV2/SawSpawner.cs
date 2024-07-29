using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SawSpawner : MonoBehaviour
{
    public GameObject sawPrefab; // Saw prefab
    public Transform[] spawnPoints; // Array of spawn points
    private float elapsedTime = 0f; // Timer to track total elapsed time
    private bool isBossSpawned = false; // Flag to check if the boss has spawned

    void Update()
    {
        if (isBossSpawned)
        {
            elapsedTime += Time.deltaTime;
        }
    }

    public void StartTimer()
    {
        isBossSpawned = true;
        elapsedTime = 0f;
    }

    public void SpawnSaws()
    {
        int minSaws = 1;
        int maxSaws = 2;

        if (elapsedTime >= 10f && elapsedTime < 20f)
        {
            minSaws = 3;
            maxSaws = 4;
        }
        else if (elapsedTime >= 20f)
        {
            minSaws = 5;
            maxSaws = spawnPoints.Length;
        }

        int sawsToSpawn = Random.Range(minSaws, maxSaws + 1);

        // Spawn the saws at random spawn points
        for (int i = 0; i < sawsToSpawn; i++)
        {
            int spawnIndex = Random.Range(0, spawnPoints.Length);
            Instantiate(sawPrefab, spawnPoints[spawnIndex].position, Quaternion.identity);
        }
    }
}