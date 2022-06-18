using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioClip gameMusic;

    private void Start()
    {
        musicSource.clip = gameMusic;
        musicSource.Play(); // Play background music once the game starts
    }

    // Play the assigned audioclip
    public void PlaySfx(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.PlayOneShot(clip);
    }
}
