using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float paddleSpeed = 5;
    [SerializeField] float xLimit = 11f; 
    [SerializeField] float bigSizeTime = 10;
    // [SerializeField] GameManager gameManager;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float fireRate = 1;
    [SerializeField] float bulletsTime = 10;
    [SerializeField] Vector3 bulletOffset;
    bool bulletsActive;

    // Access <BulletsActive> private variable and ennable power-up
    public bool BulletsActive {
        get => bulletsActive;
        set {
            bulletsActive = value;
            StartCoroutine(ShootBullets());
            Invoke("ResetBulletsActive", bulletsTime); // Execute function after a set time (delay)
        }
    }

    private void Update()
    {
        // Detect input from a key and move it in a specific direction on the x axis
        // Multiply by DELTA TIME to normalize movement units across different computers
        // Also restrict horizontal movement of the paddle
        if (Input.GetKey(KeyCode.D) && transform.position.x < xLimit){
            transform.position += Vector3.right * Time.deltaTime * paddleSpeed;
        }
        if (Input.GetKey(KeyCode.A) && transform.position.x > -xLimit){
            transform.position += Vector3.left * Time.deltaTime * paddleSpeed;
        }
    }

    // Modify paddle x scale length
    public void IncreaseSize()
    {
        // Only activate the power-up while the ball still exists
        if(GameManager.Instance.ballIsOnPlay){
            Vector3 newSize = transform.localScale;
            newSize.x = 1.2f;
            transform.localScale = newSize;
            StartCoroutine(BackToOriginalSize()); // Returns the paddle to its original size
        }
    }

    // This coroutine executes the code inside the function after a specified amount of time
    IEnumerator BackToOriginalSize()
    {
        yield return new WaitForSeconds(bigSizeTime);
        transform.localScale = new Vector3(1,1,1); // Reset paddle dimensions
        GameManager.Instance.poweUpIsActive = false; // Update variable status so other power-ups can spawn
    }

    // This coroutine will continue to execute its code while the condition is true
    IEnumerator ShootBullets()
    {
        while(BulletsActive){
            Instantiate(bulletPrefab, transform.position + bulletOffset, Quaternion.identity); // Instantiate a sigle bullet from the paddle
            yield return new WaitForSeconds(fireRate); // Wait a second between each shot
        }
    }

    void ResetBulletsActive()
    {
        bulletsActive = false;
        GameManager.Instance.poweUpIsActive = false; // Update variable status so other power-ups can spawn
    }
}
