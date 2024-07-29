using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawnerScript : MonoBehaviour
{
    public GameObject wavePrefab; // Reference to the wave prefab
    public Text waveCountText; // Reference to the Text component for displaying the wave count
    private int waveCount = 0; // Counter for the number of waves spawned
    private const int maxWaves = 3; // Maximum number of waves per level

    void Start()
    {
        UpdateWaveCountText(); // Initialize the wave count text
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && waveCount < maxWaves)
        {
            SpawnWave();
        }
    }

    void SpawnWave()
    {
        Instantiate(wavePrefab, transform.position, Quaternion.identity);
        waveCount++;
        UpdateWaveCountText(); // Update the wave count text
    }

    void UpdateWaveCountText()
    {
        waveCountText.text = "Waves Spawned: " + waveCount + "/" + maxWaves;
    }
}