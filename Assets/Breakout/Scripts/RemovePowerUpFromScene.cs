using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemovePowerUpFromScene : MonoBehaviour
{
    bool isQuitting;
    GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    
    // Function to avoid Destroy() error when quitting the game
    private void OnApplicationQuit()
    {
        isQuitting = true;
    }
    
    private void OnDestroy()
    {
        if(isQuitting){
            return;
        }

        if(gameManager != null){
            if(gameManager.powerUpOnScene){
                gameManager.powerUpOnScene = false; // Update variable status so other power-ups can spawn
            }
        }
    }
}
