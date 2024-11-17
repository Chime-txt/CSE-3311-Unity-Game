using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallButtonScript : MonoBehaviour
{
	// Get the object or object group that will interact with this single button
	[SerializeField] GameObject InteractableObjects;

	// If the object collides with the wall button, check if it is a bullet of the same color
	// before doing a certain task with the button and deleting the button
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if ((gameObject.CompareTag("RedButton") && collision.gameObject.tag.Equals("RedBullet"))
			|| (gameObject.CompareTag("BlueButton") && collision.gameObject.tag.Equals("BlueBullet")))
		{
			// Destroy the bullet
			if (collision != null)
			{
				Destroy(collision.gameObject);
			}

			// Trigger some event to happen after shooting the button
			Debug.Log("Button Activated");

			// Complete a certain action based on the object that is connected
			if (InteractableObjects != null)
			{
				CheckObjectTags(InteractableObjects);
			}

			// Removes the button after it has been activated
			Debug.Log("Button Deleted");
			Destroy(gameObject);
		}
	}

	// Depending on the tag of the object, it will do certain actions on the object
	private static void CheckObjectTags(GameObject InteractableObjects)
	{
		// Destroy the object if it has the ButtonDestroysObjects tag
		if (InteractableObjects.gameObject.tag.Equals("ButtonDestroysObjects"))
		{
			Debug.Log("Object Destroyed");
			Destroy(InteractableObjects);
			return;
		}

		// Activates the object if it has the ButtonActivatesObjects tag
		if (InteractableObjects.gameObject.tag.Equals("ButtonActivatesObjects"))
		{
			Debug.Log("Object Activated");
			InteractableObjects.SetActive(true);
			return;
		}

		// Deactivates the object if it has the ButtonDeactivatesObjects tag
		if (InteractableObjects.gameObject.tag.Equals("ButtonDeactivatesObjects"))
		{
			Debug.Log("Object Deactivated");
			InteractableObjects.SetActive(false);
			return;
		}

		if (InteractableObjects.gameObject.tag.Equals("Ground"))
		{
			Debug.Log("Switched Object State");
			Renderer io = InteractableObjects.gameObject.GetComponent<Renderer>();
			SwitchActiveState(io);
		}
	}
}