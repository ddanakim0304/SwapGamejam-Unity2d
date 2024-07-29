using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class StopEnemyMoveScript : MonoBehaviour
{

    public float moveSpeed = 5f;
    public float deadZone = -30f;
    public float moveTime = 1f;
    public float stopTime = 0.5f;
    void Start()
    {
        StartCoroutine(MoveAndStop());
    }

    // Coroutine to handle the movement and stopping
    IEnumerator MoveAndStop()
    {
        while (true)
        {
            float currentMoveTime = moveTime;

            // Move for (moveTime) seconds
            while (currentMoveTime > 0)
            {
                transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;
                currentMoveTime -= Time.deltaTime;

                if (transform.position.x < deadZone)
                {
                    Destroy(gameObject);
                    yield break; // Exit the coroutine if the object is destroyed
                }

                yield return null;
            }

            // Stop for (stopTime) seconds
            yield return new WaitForSeconds(stopTime);
        }
    }
}