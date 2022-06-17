using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    // GameObject gameManagerObj;
    GameManager gameManager;
    
    private void Start()
    {
        // gameManagerObj = GameObject.Find("GameManager");
        // gameManager = gameManagerObj.GetComponent<GameManager>();

        gameManager = FindObjectOfType<GameManager>();
        if(gameManager != null){
            gameManager.BricksOnLevel++;
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(gameManager != null){
            gameManager.BricksOnLevel--;
        }
        Destroy(gameObject);
    }
}
