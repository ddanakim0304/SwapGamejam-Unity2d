using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrength = 10;
    public LogicScript logic;
    public bool birdIsAlive = true;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && birdIsAlive)
        {
            myRigidbody.velocity = Vector2.up * flapStrength;
        } 

        if (transform.position.y > 11 || transform.position.y < -11)
        {
            gameOverFunction();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameOverFunction();
    }

    void gameOverFunction()
    {
        logic.gameOver();
        birdIsAlive = false;
    }
}
