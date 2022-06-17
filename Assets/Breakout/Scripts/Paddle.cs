using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float paddleSpeed = 5;
    [SerializeField] float xLimit = 11.7f; // Restrict horizontal movement of the paddle


    private void Update()
    {
        // Detect input from a key and move it in a specific direction on the x axis
        // Multiply by DELTA TIME to normalize movement units across different computers
        if (Input.GetKey(KeyCode.D) && transform.position.x < xLimit){
            transform.position += Vector3.right * Time.deltaTime * paddleSpeed;
        }
        if (Input.GetKey(KeyCode.A) && transform.position.x > -xLimit){
            transform.position += Vector3.left * Time.deltaTime * paddleSpeed;
        }
    }
}
