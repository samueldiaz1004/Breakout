using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   int bricksOnLevel;
   [SerializeField] int playerLives = 3;
   public bool ballIsOnPlay;
   float gameTime;
   bool gameStarted;
   [SerializeField] UIController uiController;

   // Access <bricksOnLevel> private variable
   public int BricksOnLevel{
        get => bricksOnLevel;
        set {
            bricksOnLevel = value;
            // If all bricks are destroyed
            if(bricksOnLevel == 0){
                Destroy(GameObject.Find("Ball"));
                uiController.ActivateWinnerScreen();
                gameTime = Time.time - gameTime; // Calculate time the game lasted
                print("game time: "+gameTime);
            }
        }
    }

    // Access <playerLives> private variable
    public int PlayerLives{
        get => playerLives;
        set {
            playerLives = value;
            // If the player lost all its lives
            if(playerLives == 0){
                uiController.ActivateLoseScreen();
                Destroy(GameObject.Find("Ball"));
            }
        }
    }

    // Access <gameStarted> private variable
    public bool GameStarted{
        get => gameStarted;
        set {
            gameStarted = value;
            gameTime = Time.time; // Set current time
        }
    }

}
