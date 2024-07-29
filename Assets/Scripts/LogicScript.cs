using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LogicScript : MonoBehaviour
{
    private bool isLevelComplete = false;
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
        if (isGameOver || isLevelComplete) return;

        Debug.Log("Game over.");
        gameOverScreen.SetActive(true);
        isGameOver = true;
    }

    public void EndLevel()
    {
    isLevelComplete = true;
    // Deactivate game over screen if the level is complete
    if (gameOverScreen.activeSelf)
    {
        gameOverScreen.SetActive(false);
    }
        Debug.Log("Level completed.");
        completeLevelUI.SetActive(true);
        gameOverScreen.SetActive(false);
        isGameOver = false;
    }

    // Method to end the level and load the next scene
    public void NextLevel()
    {
        // Reset game over state and level completion state
        isGameOver = false;
        isLevelComplete = false;
        gameOverScreen.SetActive(false);
        Time.timeScale = 1f; // Ensure the game time is running

        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        Debug.Log("Loading next level: " + nextSceneIndex);
        SceneManager.LoadScene(nextSceneIndex);
    }


    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }


}
