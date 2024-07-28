using UnityEngine;

public class GarbageMover : MonoBehaviour
{
    public float speed = 5f; // Speed at which the garbage moves towards the player
    private Transform player; // Reference to the player's transform
    private Vector3 initialPlayerPosition; // Initial position of the player
    public float deadZone = -30f; // Position at which the garbage is destroyed
    public float rotationSpeed = 100f; // Speed at which the garbage rotates

    void Start()
    {
        // Find the player GameObject by tag and get its transform
        GameObject playerObject = GameObject.FindWithTag("Player");
        player = playerObject.transform;
        initialPlayerPosition = player.position;

    }

    void Update()
    {
        if (player != null)
        {
            // Calculate direction towards the initial position of the player
            Vector3 direction = (initialPlayerPosition - transform.position).normalized;

            // Ensure the object always moves left
            if (direction.x > 0)
            {
                direction.x = -1;
            }

            transform.position += direction * speed * Time.deltaTime;

            // Rotate around its own axis
            transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);

            // Destroy the object if it moves past the deadZone
            if (transform.position.x < deadZone)
            {
                Destroy(gameObject);
            }
        }
    }
}