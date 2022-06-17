using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigidbody2D;
    [SerializeField] float ballSpeed = 5;
    Vector2 moveDirection;
    Vector2 currentVelocity;
    GameManager gameManager;
    Transform paddle;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        // rigidbody2D = GetComponent<Rigidbody2D>();
        // rigidbody2D.velocity = Vector2.up * ballSpeed;
        paddle = transform.parent; // Add ball object as a son of the paddle object to follow x-axis movement
    }

    private void Update()
    {
        // Throw ball with right mouse click and if it is not son of paddle so it only launches it once
        if(Input.GetMouseButtonDown(0) && !gameManager.ballIsOnPlay){
            rigidbody2D.velocity = Vector2.up * ballSpeed;
            transform.parent = null; // Remove paddle as a parent so it does not follow it
            gameManager.ballIsOnPlay = true;
            if(!gameManager.GameStarted){
                gameManager.GameStarted = true; // Start timer
            }
        }
    }

    private void FixedUpdate()
    {
        currentVelocity = rigidbody2D.velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Change direction and adjust velocity once it hits an object with collision
        moveDirection = Vector2.Reflect(currentVelocity, collision.GetContact(0).normal);
        rigidbody2D.velocity = moveDirection;

        // If the ball collides with the bottom limit of the scene...
        if(collision.transform.CompareTag("BottomLimit")){
            if(gameManager != null){
                gameManager.PlayerLives--; // Reduce player lives
                if(gameManager.PlayerLives > 0){
                    rigidbody2D.velocity = Vector2.zero;
                    transform.SetParent(paddle); // Return ball as a son of paddle
                    transform.localPosition = new Vector2(0,0.7f); // Set ofset so it is a little bit higher than the paddle
                    gameManager.ballIsOnPlay = false;
                }
            }
        }
    }
}
