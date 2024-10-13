using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class colScipt : MonoBehaviour
{
	[SerializeField] TextMeshProUGUI text;

	private void OnTriggerEnter2D(Collider2D collision)
    {
		// Print a debug regarding that an object has entered the colision area
		Debug.Log("Entered Collision Area");
    }
	void OnTriggerStay2D(Collider2D other)
	{
		text.text = "Welcome to The BIG HOUSE";
    }
	private void OnTriggerExit2D(Collider2D collision)
	{
        // Print a debug regarding that an object has exited the colision area
        Debug.Log("Exited Collision Area");
		text.text = "";
	}
}
