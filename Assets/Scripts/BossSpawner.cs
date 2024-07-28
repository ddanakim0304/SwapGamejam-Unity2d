using System.Collections;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    public GameObject bossPrefab;
    public Transform spawnPoint;
    private float timer = 0f;
    public float bossSpawnTime = 60f;
    public float bossDefeatTime = 60f;
    private GameObject bossInstance;
    public GarbageSpawner garbageSpawner;

    void Start()
    {
        garbageSpawner.enabled = false;
    }

    void Update()
    {
        // Update the timer
        timer += Time.deltaTime;

        // Check if the timer has reached the boss spawn time
        if (timer >= bossSpawnTime && bossInstance == null)
        {
            Debug.Log("Boss spawn time reached.");
            SpawnBoss();
        }

        // Check if the boss has been spawned and the defeat time has passed
        if (bossInstance != null && timer >= bossSpawnTime + bossDefeatTime)
        {
            Debug.Log("Boss defeat time reached.");
            DefeatBoss();
        }
    }

    // Method to spawn the boss
    void SpawnBoss()
    {
        Debug.Log("Boss Spawned");
        Vector3 adjustedPosition = spawnPoint.position;
        adjustedPosition.x -= 5.83f;
        bossInstance = Instantiate(bossPrefab, spawnPoint.position, spawnPoint.rotation);
        StartCoroutine(MoveBossToPosition(adjustedPosition));
        garbageSpawner.enabled = true;
    }

    IEnumerator MoveBossToPosition(Vector3 targetPosition)
    {
        float duration = 2f; // Duration of the movement in seconds
        float elapsedTime = 0f;
        Vector3 startingPosition = bossInstance.transform.position;

        while (elapsedTime < duration)
        {
            bossInstance.transform.position = Vector3.Lerp(startingPosition, targetPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the boss reaches the exact target position
        bossInstance.transform.position = targetPosition;
    }

    

    // Method to defeat the boss
    void DefeatBoss()
    {
        Debug.Log("Boss Defeated!!!");

        // Determine the target position outside the screen
        Vector3 offScreenPosition = bossInstance.transform.position;
        offScreenPosition.x += 20f; // Move 10 units to the right (adjust as needed)

        // Start the coroutine to move the boss out of the screen
        StartCoroutine(MoveBossToPosition(offScreenPosition));

        garbageSpawner.enabled = false;
        enabled = false;
    }
}