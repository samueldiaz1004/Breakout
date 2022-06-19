using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigidbody2D;
    [SerializeField] float ballSpeed = 5;
    [SerializeField] float SuperBallTime = 10;
    [SerializeField] AudioController audioController;
    [SerializeField] AudioClip bounceSfx;
    [SerializeField] float yMinSpeed = 2;
    [SerializeField] TrailRenderer trailRenderer;
    Vector2 moveDirection;
    Vector2 currentVelocity;
    // GameManager gameManager;
    Transform paddle;
    bool superBall; 
    

    // Access <superBall> private variable and ennable power-up
    public bool SuperBall{
        get => superBall;
        set {
            superBall = value;
            if(superBall){
                StartCoroutine(ResetSuperBall());
            }
        }
    }

    void Start()
    {
        // gameManager = FindObjectOfType<GameManager>();
        // rigidbody2D = GetComponent<Rigidbody2D>();
        // rigidbody2D.velocity = Vector2.up * ballSpeed;
        paddle = transform.parent; // Add ball object as a son of the paddle object to follow x-axis movement
    }

    private void Update()
    {
        // Throw ball with right mouse click and if it is not son of paddle so it only launches it once
        if(Input.GetMouseButtonDown(0) && !GameManager.Instance.ballIsOnPlay){
            rigidbody2D.velocity = Vector2.up * ballSpeed;
            transform.parent = null; // Remove paddle as a parent so it does not follow it
            GameManager.Instance.ballIsOnPlay = true;
            if(!GameManager.Instance.GameStarted){
                GameManager.Instance.GameStarted = true; // Start timer
            }
        }
    }

    private void FixedUpdate()
    {
        currentVelocity = rigidbody2D.velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Don't bounce off bricks if the super ball power-up is active
        if(collision.transform.CompareTag("Brick") && SuperBall){
            rigidbody2D.velocity = currentVelocity; // Keep current velocity
            return;
        }

        // Change direction and adjust velocity once it hits an object with collision
        moveDirection = Vector2.Reflect(currentVelocity, collision.GetContact(0).normal);

        if(Mathf.Abs(moveDirection.y) < yMinSpeed){
            moveDirection.y = yMinSpeed * Mathf.Sign(moveDirection.y); // Improves gameplay by keeping a minimum speed while bouncing off other objects
        }

        rigidbody2D.velocity = moveDirection;
        audioController.PlaySfx(bounceSfx); // Play bounce audioclip

        // If the ball collides with the bottom limit of the scene...
        if(collision.transform.CompareTag("BottomLimit")){
            if(GameManager.Instance != null){
                GameManager.Instance.PlayerLives--; // Reduce player lives
                if(GameManager.Instance.PlayerLives > 0){
                    rigidbody2D.velocity = Vector2.zero;
                    transform.SetParent(paddle); // Return ball as a son of paddle
                    transform.localPosition = new Vector2(0,0.7f); // Set ofset so it is a little bit higher than the paddle
                    GameManager.Instance.ballIsOnPlay = false;
                }
            }
        }
    }

    // This coroutine executes the code inside the function after a specified amount of time
    IEnumerator ResetSuperBall()
    {
        trailRenderer.enabled = true; // Activate trail render effect while the ball has the power-up
        yield return new WaitForSeconds(SuperBallTime);
        trailRenderer.enabled = false;
        GameManager.Instance.poweUpIsActive = false; // Update variable status so other power-ups can spawn
        superBall = false;
    }
}
