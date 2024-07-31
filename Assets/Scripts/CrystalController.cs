using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalController : MonoBehaviour
{
    // Destroy the crystal whenever the player comes into contact with it.
    void OnTriggerEnter2D(Collider2D other)
    {
        //if (other.gameObject.CompareTag("Player"))
        //{
            // Destroy the crystal
            //Destroy(gameObject);
        //}
    }
}
