using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuRandomMove : MonoBehaviour
{
    // Define the boundaries for movement
    private float minX = -7.5f;
    private float maxX = 7.5f;
    private float minY = -4.5f;
    private float maxY = 4.5f;

    // Speed of movement and rotation
    public float moveSpeed = 2f;
    public float rotationSpeed = 100f;

    // Current direction of movement
    private Vector2 direction;

    void Start()
    {
        // Randomly assign an initial direction
        AssignRandomDirection();
    }

    // Update is called once per frame
    void Update()
    {
        // Move the player in the current direction
        transform.Translate(direction * moveSpeed * Time.deltaTime);

        // Rotate the player in a circle
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);

        // Check for collisions with the screen edges and bounce back perpendicularly
        if (transform.position.x <= minX || transform.position.x >= maxX)
        {
            direction.x = -direction.x;
            // Ensure the player stays within bounds and moves away from the edge
            float clampedX = Mathf.Clamp(transform.position.x, minX, maxX);
            transform.position = new Vector2(clampedX, transform.position.y);
        }
        if (transform.position.y <= minY || transform.position.y >= maxY)
        {
            direction.y = -direction.y;
            // Ensure the player stays within bounds and moves away from the edge
            float clampedY = Mathf.Clamp(transform.position.y, minY, maxY);
            transform.position = new Vector2(transform.position.x, clampedY);
        }
    }

    // Assign a random direction
    void AssignRandomDirection()
    {
        float angle = Random.Range(0f, 360f);
        direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)).normalized;
    }
}