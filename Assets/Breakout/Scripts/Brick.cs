using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    // GameObject gameManagerObj;
    // GameManager gameManager;
    [SerializeField] GameObject explosionPrefab;
    [SerializeField] GameObject[] powerUpsPrefabs;
    [SerializeField] int powerUpChance = 20;
    bool isQuitting;
    
    private void Start()
    {
        // gameManagerObj = GameObject.Find("GameManager");
        // gameManager = gameManagerObj.GetComponent<GameManager>();

        GameManager.Instance = FindObjectOfType<GameManager>();
        if(GameManager.Instance != null){
            GameManager.Instance.BricksOnLevel++; // Add all the brick object instances while the scene loads
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(GameManager.Instance != null){
            GameManager.Instance.BricksOnLevel--; // Delete this game object and reduce the total amount of bricks once it has collided with the ball
        }
        Instantiate(explosionPrefab, transform.position, Quaternion.identity); // Instantiate explotion prefab in the block position and rotation
        Destroy(gameObject);
    }

    // Function to avoid Destroy() error when quitting the game
    private void OnApplicationQuit()
    {
        isQuitting = true;
    }

    // Will execute following code when this instance of the game object is destroyed
    private void OnDestroy()
    {
        if(isQuitting){
            return;
        }
        
        // Don't instantiate a new power-up if another one is on the scene
        if(!GameManager.Instance.powerUpOnScene){
            int possibility = Random.Range(0,100); // Calculate the posibility of a power-up dropping from this destroyed brick
            if(possibility < powerUpChance){
                int randomPowerUp = Random.Range(0,powerUpsPrefabs.Length);
                Instantiate(powerUpsPrefabs[randomPowerUp], transform.position, Quaternion.identity); // Instantiate a random power-up
                GameManager.Instance.powerUpOnScene = true; // Update variable status
            }
        }
    }
}
