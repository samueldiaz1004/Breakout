using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basics : MonoBehaviour
{
    private void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.D)){
            transform.position += Vector3.right * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A)){
            transform.position += Vector3.left * Time.deltaTime;
        }
    }
}
