using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrength = 10;
    public LogicScript logic;
    public bool birdIsAlive = true;
    private Animator animator; // Reference to the Animator
    private AudioSource audioSource; // Reference to the AudioSource

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>(); // Get the Animator component
        audioSource = GetComponent<AudioSource>(); // Get the AudioSource component
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && birdIsAlive)
        {
            myRigidbody.velocity = Vector2.up * flapStrength;
            animator.SetTrigger("Jump"); // Trigger the jump animation
            audioSource.Play(); // Play the jump sound
        } 

        if (transform.position.y > 8.8 || transform.position.y < -8.8)
        {
            gameOverFunction();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Wave")
        {
            gameOverFunction();
        }
    }

    void gameOverFunction()
    {
        logic.gameOver();
        birdIsAlive = false; // Set birdIsAlive to false to stop further jumps
    }
}