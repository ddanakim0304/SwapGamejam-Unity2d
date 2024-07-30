using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(AudioSource))]
public class WaveMoveScript : MonoBehaviour
{
    public float speed = 10f;
    public AudioClip activationClip;

    private Rigidbody2D rb;
    private BoxCollider2D boxCollider;
    private AudioSource audioSource;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true; // Make the Rigidbody2D kinematic if you don't want it to be affected by physics

        boxCollider = GetComponent<BoxCollider2D>();
        boxCollider.isTrigger = true; // Set the BoxCollider2D to be a trigger

        audioSource = GetComponent<AudioSource>();
        if (activationClip != null)
        {
            audioSource.clip = activationClip;
            audioSource.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);

        if (transform.position.x >= 18f)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger detected with: " + other.gameObject.name);

        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("Triggered with Enemy: " + other.gameObject.name);
            Destroy(other.gameObject);
        }
    }
}