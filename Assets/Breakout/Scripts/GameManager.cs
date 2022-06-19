using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
   [SerializeField] UIController uiController;
   [SerializeField] int playerLives = 3;
   int bricksOnLevel;
   public bool ballIsOnPlay;
   float gameTime;
   bool gameStarted;
   public bool powerUpOnScene;
   public bool poweUpIsActive;
   
   // Create game manager before start so other objects can reference it
   // Transform game manager into a singleton
   private void Awake()
   {
        if(Instance == null){
            Instance = this;
        }
   }

   // Access <bricksOnLevel> private variable
   public int BricksOnLevel{
        get => bricksOnLevel;
        set {
            bricksOnLevel = value;
            // If all bricks are destroyed
            if(bricksOnLevel == 0){
                Destroy(GameObject.Find("Ball"));
                uiController.ActivateWinnerScreen();
                gameTime = Time.time - gameTime; // Calculate total time the game lasted
                uiController.UpdateTime(string.Format("{0:N2}", gameTime)); // Show it on the screen
            }
        }
    }

    // Access <playerLives> private variable
    public int PlayerLives{
        get => playerLives;
        set {
            playerLives = value;
            uiController.UpdateLives(playerLives); // Update current player lives in the UI
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

    // Function to quit game with esc key
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            Application.Quit();
        }
    }

}
