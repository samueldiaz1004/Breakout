using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    [SerializeField] float speed = 1;

    void Update()
    {
        transform.Translate(Vector2.down * Time.deltaTime * speed); // Simulate the item constantly falling
    }

    private void OnTriggerEnter2D(Collider2D collison)
    {
        if(collison.transform.CompareTag("Player")){
            Paddle paddle = FindObjectOfType<Paddle>();
            if(paddle != null){
                paddle.BulletsActive = true; // Activate power-up
            }
            GameManager gameManager = FindObjectOfType<GameManager>();
            if(gameManager != null){
                gameManager.poweUpIsActive = true; // // Update variable status so no more power-ups spawn
            }
            Destroy(gameObject);
        }
    }

}
