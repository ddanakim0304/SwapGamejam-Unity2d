using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public GameObject gameOverScreen;
    public BossSpawner bossSpawner;
    public GameObject bird;
    public BirdScript birdScript;
    public GameObject completeLevelUI;

    private bool isGameOver = false;

    void Start()
    {
        birdScript = bird.GetComponent<BirdScript>();
        Debug.Log("Game started. BirdScript initialized.");
    }

    public void restartGame()
    {
        Debug.Log("Restarting game...");
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        if (isGameOver) return;

        Debug.Log("Game over.");
        gameOverScreen.SetActive(true);
        Time.timeScale = 0f;
        isGameOver = true;

        // Delete the boss if it exists
        if (bossSpawner != null && bossSpawner.bossInstance != null)
        {
            Destroy(bossSpawner.bossInstance);
            Debug.Log("Boss destroyed.");
        }
    }

    public void EndLevel()
    {
        Debug.Log("Level completed.");
        completeLevelUI.SetActive(true);
    }

    // Method to end the level and load the next scene
    public void NextLevel()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        Debug.Log("Loading next level: " + nextSceneIndex);
        SceneManager.LoadScene(nextSceneIndex);
    }


    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }


}
