using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Proceed : MonoBehaviour
{
    public void NextLevel()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        Debug.Log("Loading next level: " + nextSceneIndex);
        SceneManager.LoadScene(nextSceneIndex);
    }
}
