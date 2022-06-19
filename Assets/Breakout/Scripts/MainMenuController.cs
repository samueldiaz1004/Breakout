using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip buttonPressedSfx;
    [SerializeField] GameObject loadGameButton;
    void LoadGameScene()
    {
        SceneManager.LoadScene("Game");
    }

    public void LoadSceneWithDelay(float delay)
    {
        loadGameButton.SetActive(false); // Hide btn so user can only click it once
        audioSource.clip = buttonPressedSfx;
        audioSource.Play(); // Play sfx
        Invoke("LoadGameScene", delay); // Load next scene with a delay so the audio has enough time to play
    }

    public void PlaySfx()
    {
        audioSource.PlayOneShot(buttonPressedSfx);
    }
}
