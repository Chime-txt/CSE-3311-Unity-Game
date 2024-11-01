using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedGemCollect : MonoBehaviour
{
    // Reference to the Red Portal
    public GameObject redPortal;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the colliding object has the "Red" tag
        if (collision.CompareTag("Red"))
        {
            Debug.Log("Red player collected the Red Gem!");
            redPortal.SetActive(true); // Activate the Red Portal
            Destroy(gameObject); // Destroy the Red Gem
        }
    }
}