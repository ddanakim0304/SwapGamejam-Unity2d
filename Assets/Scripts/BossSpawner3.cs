using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossSpawner3 : MonoBehaviour
{
    public GameObject bossPrefab;
    public Transform spawnPoint;
    private float timer = 0f;
    public float bossSpawnTime = 60f;
    public float bossDefeatTime = 60f;
    public GameObject bossInstance;
    public GameObject bossName; // Reference to the boss's name text
    private bool bossNameActivated = false;
    public LogicScript logicScript;
    public ShellSpawner shellSpawner;

    void Update()
    {
        // Update the timer
        timer += Time.deltaTime;

        // Check if the timer is three seconds before the boss spawn time and activate the boss name
        if (!bossNameActivated && timer >= bossSpawnTime - 3f)
        {
            Debug.Log("Activating boss name.");
            bossName.SetActive(true);
            bossNameActivated = true;
        }

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
    public float BossPosition = 6f;
    void SpawnBoss()
    {
        Debug.Log("Boss Spawned");
        
        Vector3 adjustedPosition = spawnPoint.position;
        adjustedPosition.x -= BossPosition;
        bossInstance = Instantiate(bossPrefab, spawnPoint.position, spawnPoint.rotation);
        StartCoroutine(MoveBossToPosition(adjustedPosition));

        shellSpawner.StartTimer();
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
        offScreenPosition.x += 40f;

        // Start the coroutine to move the boss out of the screen
        StartCoroutine(MoveBossToPosition(offScreenPosition));

        enabled = false;

        // Check if the game is not over before calling GameClear
        if (!logicScript.isGameOver)
        {
            logicScript.GameClear();
        }

    }
}