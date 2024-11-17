using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PressurePlateScript : MonoBehaviour
{
	[SerializeField] LinkedPressurePlatesScript LinkedPlates;
	[SerializeField] GameObject InteractableObjects;

	[SerializeField] GameObject PlayerObject;

	private int noPlayersOnPressurePlate;
    // Get the music
    [SerializeField] AudioClip audioclip;
    [SerializeField] AudioSource audioSource;

    void Start()
	{ 

        audioSource = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>();
		noPlayersOnPressurePlate = 0;
		gameObject.GetComponent<Renderer>().enabled = true;
	}

	private void OnTriggerEnter2D(Collider2D other){
		// Check if one player is standing on the pressure plate
		if (other.gameObject.tag.Equals("Red") || other.gameObject.tag.Equals("Blue"))
		{
			Debug.Log("Entered Pressure Plate");
			audioSource.PlayOneShot(audioclip);
			// Add to the number of players on the pressure plate
			if (LinkedPlates != null)
			{
				Debug.Log("Linked Enter");
				noPlayersOnPressurePlate = LinkedPlates.addToNoPlayers();
			}
			else
			{
				noPlayersOnPressurePlate++;
			}

			// Disable the Sprite Renderer for the trigger pressure plate
			gameObject.GetComponent<Renderer>().enabled = false;
			

			// Check if there is only one player when one or more players enters the pressure plate
			if (noPlayersOnPressurePlate == 1)
			{
				Debug.Log("Activated Pressure Plate");

				// Switch between states depending on the object (Active)
				SwitchActiveState(InteractableObjects);
			}
		}
    }

	// Function that checks if one or both players has left the pressure plate
	private void OnTriggerExit2D(Collider2D other)
	{
		// Check if one player has left the pressure plate
		if (other.gameObject.tag.Equals("Red") || other.gameObject.tag.Equals("Blue"))
		{
			Debug.Log("Left Pressure Plate");

			if (LinkedPlates != null)
			{
				Debug.Log("Linked Left");
				noPlayersOnPressurePlate = LinkedPlates.subToNoPlayers();
			}
			else
			{
				noPlayersOnPressurePlate--;
			}

			// Reenable the pressure plate, regardless if linked or unlinked
			gameObject.GetComponent<Renderer>().enabled = true;
			
			// Then check if no players are on the pressure plate
			if (noPlayersOnPressurePlate == 0)
			{
				Debug.Log("Deactivated Pressure Plate");

				// Switch between states depending on the object (Not Active)
				SwitchActiveState(InteractableObjects);
			}
			else
			{
				Debug.Log("Still Active Pressure Plate");
			}
		}
	}

	private static void SwitchActiveState(GameObject InteractableObjects)
	{
		// Check if the object exists
		if (InteractableObjects != null)
		{
			if (InteractableObjects.activeSelf)
			{
				InteractableObjects.SetActive(false);
			}
			else if (!InteractableObjects.activeSelf)
			{
				InteractableObjects.SetActive(true);
			}
		}
	}
}
