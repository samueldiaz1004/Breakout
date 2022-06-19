using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    [SerializeField] AudioClip audioClip;
    
    private void OnTriggerEnter2D(Collider2D collison)
    {
        if(collison.transform.CompareTag("Player")){
            Paddle paddle = FindObjectOfType<Paddle>();
            AudioController audioController = FindObjectOfType<AudioController>();
            if(paddle != null){
                audioController.PlaySfx(audioClip);
                paddle.BulletsActive = true; // Activate power-up
            }
            // GameManager gameManager = FindObjectOfType<GameManager>();
            if(GameManager.Instance != null){
                GameManager.Instance.poweUpIsActive = true; // // Update variable status so no more power-ups spawn
            }
            Destroy(gameObject);
        }
    }

}
