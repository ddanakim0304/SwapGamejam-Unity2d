using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkingtonScript : MonoBehaviour
{
    public GameObject sawSpawnerObject; // Reference to the GameObject with the SawSpawner component
    private SawSpawner sawSpawner; // Reference to the SawSpawner instance
    private float attackInterval = 5.0f; // Initial interval
    private float minInterval = 1.0f; // Minimum interval
    private float intervalDecreaseRate = 0.1f; // Rate at which the interval decreases

    void Start()
    {
        // Find the GameObject with the tag "SawSpawner"
        sawSpawnerObject = GameObject.FindWithTag("SawSpawner");
        if (sawSpawnerObject != null)
        {
            // Get the SawSpawner component from the GameObject
            sawSpawner = sawSpawnerObject.GetComponent<SawSpawner>();
            if (sawSpawner != null)
            {
                StartCoroutine(AttackRoutine());
                StartCoroutine(DecreaseIntervalRoutine());
            }
        }
    }

    IEnumerator AttackRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(attackInterval);
            sawSpawner.SpawnSaws(); // Call the SpawnSaws method
        }
    }

    IEnumerator DecreaseIntervalRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(2.0f);
            // Decrease the attack interval
            attackInterval = Mathf.Max(minInterval, attackInterval - intervalDecreaseRate);
        }
    }
}