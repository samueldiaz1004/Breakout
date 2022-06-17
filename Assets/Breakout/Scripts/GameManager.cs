using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   int bricksOnLevel;
   [SerializeField] int playerLives = 3;

   public int BricksOnLevel{
        get => bricksOnLevel;
        set {
            bricksOnLevel = value;
            if(bricksOnLevel == 0){
                Destroy(GameObject.Find("Ball"));
            }
        }
   }

      public int PlayerLives{
        get => playerLives;
        set {
            playerLives = value;
            if(playerLives == 0){
                Destroy(GameObject.Find("Ball"));
            }
        }
   }

}
