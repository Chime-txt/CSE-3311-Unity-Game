using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SkySpawnScript : MonoBehaviour
{
	// Gets the GameObject that is connected to this script
	// In this case, the object is the SkySpawner
	[SerializeField] GameObject sky;
	// Sets how long the sky prefab should spawn in after the prior sky prefab
	[SerializeField] float skySpawnerRate = 5;
	// Keeps track of the time until the sky can be spawned
	private float skyTimer;

	// Start is called before the first frame update
	void Start()
	{
		// Initially create a sky at the beginning
		spawnSky();

		// Set the sky timer to 0
		skyTimer = 0;
	}

	// Update is called once per frame
	void Update()
	{
		// Checks if the skyTimer exceeds the skySpawnerRate
		if (skyTimer < skySpawnerRate)
		{
			// Add the time difference to skyTimer if condition is true
			skyTimer += Time.deltaTime;
		}
		else
		{
			// Spawn a new sky and set the timer back to zero if condition is false
			spawnSky();
			skyTimer = 0;
		}
	}

	// Create a new game object clone of Sky
	void spawnSky()
	{
		Debug.Log("Sky Created");
		Instantiate(sky, transform.position, transform.rotation);
	}
}
