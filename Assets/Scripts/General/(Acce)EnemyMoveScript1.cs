using UnityEngine;

public class AccelerateEnemyMoveScript1 : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float acceleration = 0.1f; // Rate of acceleration
    public float deadZone = -30f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Increase the move speed by the acceleration rate
        moveSpeed += acceleration * Time.deltaTime;

        // Move the enemy to the left
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;

        // Destroy the enemy if it goes beyond the dead zone
        if (transform.position.x < deadZone)
        {
            Destroy(gameObject);
        }
    }
}