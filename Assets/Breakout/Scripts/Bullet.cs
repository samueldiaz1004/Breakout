using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed = 5;
    
    void Update()
    {
        transform.Translate(Vector2.up * Time.deltaTime * speed); // Simulate the bullet constantly going up
    }

    private void OnTriggerEnter2D(Collider2D collison)
    {
        // When a bullet enters in contact with brick, destroy the brick and itself
        if(collison.transform.CompareTag("Brick")){
            Destroy(collison.gameObject);
            Destroy(gameObject);
        }
    }
}
