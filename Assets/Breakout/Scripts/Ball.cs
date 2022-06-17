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

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        // rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.velocity = Vector2.up * ballSpeed;
    }

    private void FixedUpdate()
    {
        currentVelocity = rigidbody2D.velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        moveDirection = Vector2.Reflect(currentVelocity, collision.GetContact(0).normal);
        rigidbody2D.velocity = moveDirection;

        if(collision.transform.CompareTag("BottomLimit")){
            if(gameManager != null){
                gameManager.PlayerLives--;
            }
        }
    }
}
