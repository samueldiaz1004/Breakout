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
    [SerializeField] GameObject tryAgainButtonLs;
    [SerializeField] GameObject MainMenuButtonLs;
    [SerializeField] GameObject tryAgainButtonWn;
    [SerializeField] GameObject MainMenuButtonWn;

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

    void TryAgain()
    {
        SceneManager.LoadScene("Game");
    }

    void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadSceneWithDelay(string functionName)
    {
        // Hide btns so user can only click it once
        tryAgainButtonLs.SetActive(false);
        MainMenuButtonLs.SetActive(false);
        tryAgainButtonWn.SetActive(false);
        MainMenuButtonWn.SetActive(false);

        audioController.PlaySfx(buttonPressedSfx); // Play sfx

        Invoke(functionName, 1); // Load next scene with a delay so the audio has enough time to play
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
