using System.Collections;
using UnityEngine;

public class OrcaScript : MonoBehaviour
{
    public float speed = 5f; // Speed of the orca's movement
    private Vector3 originalPosition;
    public float stopAttack = 40f; // Duration for which the attack should continue
    public Animator animator; // Reference to the Animator component
    private bool isAttacking = false; // Flag to check if the orca is attacking
    private float idleSpeed = 2f; // Speed of the idle movement
    private float idleDirection = 1f; // Direction of the idle movement

    void Start()
    {
        originalPosition = new Vector3(8f, transform.position.y, 0f); // Set the original position to (8, current y, 0)
        animator = GetComponent<Animator>(); // Get the Animator component
        StartCoroutine(AutomaticAttack()); // Start the automatic attack coroutine
    }

    void Update()
    {
        if (!isAttacking)
        {
            IdleMovement(); // Perform idle movement when not attacking
        }
    }

    void IdleMovement()
    {
        // Move up and down within the range -5.3 < y < 5.2
        transform.position += new Vector3(0, idleSpeed * idleDirection * Time.deltaTime, 0);

        // Reverse direction if the orca reaches the boundaries
        if (transform.position.y > 5.2f)
        {
            transform.position = new Vector3(transform.position.x, 5.2f, transform.position.z);
            idleDirection = -1f;
        }
        else if (transform.position.y < -5.3f)
        {
            transform.position = new Vector3(transform.position.x, -5.3f, transform.position.z);
            idleDirection = 1f;
        }
    }

    IEnumerator AutomaticAttack()
    {
        yield return new WaitForSeconds(5f); // Initial delay of 5 seconds

        float elapsedTime = 0f;
        while (elapsedTime < stopAttack)
        {
            float randomInterval = Random.Range(2f, 5f); // Random interval between 0.5 and 3 seconds
            yield return new WaitForSeconds(randomInterval); // Wait for the random interval
            yield return StartCoroutine(Attack()); // Perform the attack and wait until it completes
            elapsedTime += randomInterval; // Update the elapsed time
        }
    }

    IEnumerator Attack()
    {
        isAttacking = true; // Set attacking flag to true

        // Update originalPosition to include the current y position
        originalPosition = new Vector3(8f, transform.position.y, 0f);
        Debug.Log("Original Position Set: " + originalPosition);

        // Move to position.x = -7
        while (transform.position.x > -7.5f)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(-7.5f, transform.position.y, transform.position.z), speed * Time.deltaTime);
            Debug.Log("Moving to Attack Position: " + transform.position);
            yield return null;
        }

        // Delay at the attack position
        Debug.Log("Reached Attack Position: " + transform.position);
        yield return new WaitForSeconds(0.5f);

        // Move back to the original position
        while (transform.position != originalPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, originalPosition, speed * Time.deltaTime);
            Debug.Log("Returning to Original Position: " + transform.position);
            yield return null;
        }

        Debug.Log("Returned to Original Position: " + transform.position);
        isAttacking = false; // Set attacking flag to false
    }
}