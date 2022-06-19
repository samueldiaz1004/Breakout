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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // When a bullet enters in contact with brick or the top limit, it will destroy itself
        if(collision.transform.CompareTag("Brick") || collision.transform.CompareTag("TopLimit")){
            Destroy(gameObject);
        }
    }
}
