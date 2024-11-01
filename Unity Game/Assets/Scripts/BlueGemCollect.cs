using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueGemCollect : MonoBehaviour
{
    // Reference to the Blue Portal
    public GameObject bluePortal;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the colliding object has the "Blue" tag
        if (collision.CompareTag("Blue"))
        {
            Debug.Log("Blue player collected the Blue Gem!");
            bluePortal.SetActive(true); // Activate the Blue Portal
            Destroy(gameObject); // Destroy the Blue Gem
        }
    }
}
