using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperBall : MonoBehaviour
{
    [SerializeField] AudioClip audioClip;
    
    private void OnTriggerEnter2D(Collider2D collison)
    {
        if(collison.transform.CompareTag("Player")){
            Ball ball = FindObjectOfType<Ball>();
            AudioController audioController = FindObjectOfType<AudioController>();
            if(ball != null){
                audioController.PlaySfx(audioClip);
                ball.SuperBall = true; // Activate power-up
            }
            // GameManager gameManager = FindObjectOfType<GameManager>();
            if(GameManager.Instance != null){
                GameManager.Instance.poweUpIsActive = true; // // Update variable status so no more power-ups spawn
            }
            Destroy(gameObject);
        }
    }
}
