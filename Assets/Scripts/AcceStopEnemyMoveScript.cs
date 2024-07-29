using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class AccelarateSlowEnemyMoveScript : MonoBehaviour
{
    public float fastMoveSpeed = 15f;
    public float slowMoveSpeed = 5f;
    public float deadZone = -30f;
    public float switchTime = 0.6f; // Time to switch between fast and slow

    private bool isMovingFast = true;
    private float timer;

    void Start()
    {
        timer = switchTime;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            isMovingFast = !isMovingFast;
            timer = switchTime;
        }

        float currentMoveSpeed = isMovingFast ? fastMoveSpeed : slowMoveSpeed;
        transform.position = transform.position + (Vector3.left * currentMoveSpeed) * Time.deltaTime;

        if (transform.position.x < deadZone)
        {
            Destroy(gameObject);
        }
    }
}