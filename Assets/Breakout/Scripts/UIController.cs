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
    [SerializeField] AudioController audioController;
    [SerializeField] AudioClip buttonPressedSfx;
    [SerializeField] AudioClip loseLifeSfx;

    //////////////////////////////////////////////////
    /*Functions to change scene (used with a button)*/
    public void ActivateLoseScreen()
    {
        audioController.UpdateMusicVolume(0.5f); // Lower background music volume
        loseScreen.SetActive(true);
    }

    public void ActivateWinnerScreen()
    {
        audioController.UpdateMusicVolume(0.5f); // Lower background music volume
        winnerScreen.SetActive(true);
    }

    public void TryAgain()
    {
        audioController.PlaySfx(buttonPressedSfx);
        SceneManager.LoadScene("Game");
    }

    public void MainMenu()
    {
        audioController.PlaySfx(buttonPressedSfx);
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
        audioController.PlaySfx(loseLifeSfx);
    }

    public void UpdateTime(string text)
    {
        gameTimeUI.text = "Time: " + text; // Show time in a UI text field
    }

}
