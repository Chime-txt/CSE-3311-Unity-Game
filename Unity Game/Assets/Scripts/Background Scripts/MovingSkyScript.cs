using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingSkyScript : MonoBehaviour
{
	[SerializeField] float moveSpeed = 5;
	[SerializeField] float deleteSkyZone = -20;

	// Update is called once per frame
	void Update()
	{
		// On every variable frame, move the sky to the left by the move speed times the time difference
		transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;

		// Deletes the sky if the sky goes off screen
		if (transform.position.x < deleteSkyZone)
		{
			Debug.Log("Sky Deleted");
			Destroy(gameObject);
		}
	}
}
