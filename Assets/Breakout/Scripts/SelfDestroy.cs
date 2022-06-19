using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroy : MonoBehaviour
{
    [SerializeField] float delay = 5;

    void Start()
    {
        Destroy(gameObject, delay); // Destroy game object after a set number of seconds existing
    }
    
    public void DestroyFromEvent()
    {
        Destroy(gameObject);
    }
}
