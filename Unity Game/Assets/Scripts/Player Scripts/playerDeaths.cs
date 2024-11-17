using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerDeaths : MonoBehaviour
{
	[Header("Player Variables")]
	[SerializeField] Animator animator;
	[SerializeField] playerMovement playerMove;
	[SerializeField] Rigidbody2D rigidBody2D;
	[SerializeField] float timeTillDeath = 1.4f;

	// Death planes
	[Header("Death Planes")]
	[SerializeField] GameObject deathPlanes;

	// The level manager controls the UI elements
	[Header("Level Manager")]
	[SerializeField] LevelManagerScript levelManager;

	// Lock the collision before players are about to die
	private bool deathLock;

    [Header("Audio Management")]
    [SerializeField] AudioSource audioSource;
    [SerializeField] private AudioClip audioClip;
    // Start is called before the first frame update
    void Start()
	{
		audioSource = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>();
		deathLock = false;
		playerMove = GetComponent<playerMovement>();
	}

	// This function detects whether the player has collided with any enemy type before killing the player
	// To trigger this function, the player has to touch the enemy of a different color or the other player
	private void OnCollisionEnter2D(Collision2D collision)
	{
		// Check if the death lock is not being used
		if (!deathLock)
		{
			if (collision.gameObject.tag.Equals("Purple")) // If the player collides with PurpleEnemy
			{
				LockKillPlayer();
			}
			else if ((collision.gameObject.tag.Equals("Blue") && gameObject.tag.Equals("Red"))
				|| (collision.gameObject.tag.Equals("Red") && gameObject.tag.Equals("Blue"))) // If the players collide with each other
			{
				LockKillPlayer();
			}
			else if (collision.gameObject.tag.Equals("BlueEnemy") && gameObject.tag.Equals("Red")) // If the player collides with RedEnemy
			{
				LockKillPlayer();
			}
			else if (collision.gameObject.tag.Equals("RedEnemy") && gameObject.tag.Equals("Blue"))// If the player collides with RedEnemy
			{
				LockKillPlayer();
			}
		}
	}

	// This function detects whether the player has passed through the death plane before killing the player
	// To trigger this function, the player has to enter the death plane
	private void OnTriggerEnter2D(Collider2D trigger)
	{
		// Death Plane Check
		if (deathPlanes != null)
		{
			// Check if the death lock is not being used
			if (!deathLock)
			{
				// If player enters the Death Planes, kill the player
				if (trigger.CompareTag("Death Planes"))
				{
					Debug.Log("Player Died By Death Plane");
					LockKillPlayer();
				}
			}
		}

		// Barrier Check
		if (trigger.CompareTag("RedBarrier") && gameObject.CompareTag("Blue") ||
			trigger.CompareTag("BlueBarrier") && gameObject.CompareTag("Red"))
		{
			Debug.Log("Player Died By Barrier");
			LockKillPlayer();
		}
	}

	// This function takes the lock to prevent other functions with collisions from running
	// To run this function, the player must first collide with an enemy or another player
	// or go out of bounds and trigger a death plane
	private void LockKillPlayer()
	{

		// Check if the death lock is not being used
		if (!deathLock)
		{
			// Lock the code immediately before safely executing the rest of the code
			deathLock = true;
			Debug.Log(gameObject.name + " Death Lock = " + deathLock);

			// Play audio, if it exists
			if (audioSource != null)
			{
				audioSource.PlayOneShot(audioClip);
			}
			
			// Then kill the player safely
			KillPlayer();
		}
	}

	// This function kills the current player and triggers the game over screen
	// To trigger this function, the player has to collide with other enemies of different colors
	private void KillPlayer()
	{
		Debug.Log("A Player Is Dead");

		// Disable all player movement
		playerMove.isAbleToMove = false;
		rigidBody2D.gravityScale = 0.01f;
		rigidBody2D.velocity = new Vector2(0.0f, 0.0f);

		// Call a coroutine to play the death animation
		StartCoroutine(DeathAnimation());

		IEnumerator DeathAnimation()
		{
			// Play the character death animation
			animator.SetBool("isDead", true);
	
			// Waits for the current player to finish its death animation
			yield return new WaitForSeconds(timeTillDeath);

			// Destroys the character
			Destroy(gameObject);

			// Trigger the game over function
			levelManager.gameOver();
		}
	}
}
