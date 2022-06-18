using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    // GameObject gameManagerObj;
    GameManager gameManager;
    [SerializeField] GameObject explosionPrefab;
    
    private void Start()
    {
        // gameManagerObj = GameObject.Find("GameManager");
        // gameManager = gameManagerObj.GetComponent<GameManager>();

        gameManager = FindObjectOfType<GameManager>();
        if(gameManager != null){
            gameManager.BricksOnLevel++; // Add all the brick object instances while the scene loads
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(gameManager != null){
            gameManager.BricksOnLevel--; // Delete this game object and reduce the total amount of bricks once it has collided with the ball
        }
        Instantiate(explosionPrefab, transform.position, Quaternion.identity); // Instantiate explotion prefab in the block position and rotation
        Destroy(gameObject);
    }
}
