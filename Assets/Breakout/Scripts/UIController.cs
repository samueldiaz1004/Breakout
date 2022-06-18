using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] GameObject loseScreen;
    [SerializeField] GameObject winnerScreen;
    [SerializeField] Text gameTimeUI;
    [SerializeField] GameObject[] hearts;
    
    //////////////////////////////////////////////////
    /*Functions to change scene (used with a button)*/
    public void ActivateLoseScreen()
    {
        loseScreen.SetActive(true);
    }

    public void ActivateWinnerScreen()
    {
        winnerScreen.SetActive(true);
    }

    public void TryAgain()
    {
        SceneManager.LoadScene("Game");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    //////////////////////////////////////////////////

    // Only show the player lives in the active UI heart containers
    public void UpdateLives(int currentLives)
    {
        for(int i = 0; i < hearts.Length; i++){
            if(i >= currentLives){
                hearts[i].SetActive(false);
            }
        }
    }

    public void UpdateTime(string text)
    {
        gameTimeUI.text = "Time: " + text; // Show time in a UI text field
    }

}
