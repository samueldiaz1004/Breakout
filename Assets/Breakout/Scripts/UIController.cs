using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    [SerializeField] GameObject loseScreen;
    [SerializeField] GameObject winnerScreen;
    
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

}
