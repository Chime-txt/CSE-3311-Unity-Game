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

	void Start()
	{
		noPlayersOnPressurePlate = 0;
		InteractableObjects.SetActive(false);
		gameObject.GetComponent<Renderer>().enabled = true;
	}

	private void OnTriggerEnter2D(Collider2D other){
		// Check if one player is standing on the pressure plate
		if (other.gameObject.tag.Equals("Red") || other.gameObject.tag.Equals("Blue"))
		{
			Debug.Log("Entered Pressure Plate");

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
			// Then check if there is one player on the pressure plate
			if (noPlayersOnPressurePlate == 1)
			{
				Debug.Log("Activated Pressure Plate");
				gameObject.GetComponent<Renderer>().enabled = false;
				if (InteractableObjects != null)
					InteractableObjects.SetActive(true);
			}
        }
    }

	// other.gameObject.tag.Equals("Blue")
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
			// Then check if no players are on the pressure plate
			if (noPlayersOnPressurePlate == 0)
			{
				Debug.Log("Deactivated Pressure Plate");
				gameObject.GetComponent<Renderer>().enabled = true;
				if (InteractableObjects != null)
					InteractableObjects.SetActive(false);
			}
			else
			{
				Debug.Log("Still Active Pressure Plate");
				gameObject.GetComponent<Renderer>().enabled = false;
				if (InteractableObjects != null)
					InteractableObjects.SetActive(true);
			}
		}
	}
}
