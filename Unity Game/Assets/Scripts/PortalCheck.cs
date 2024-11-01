using UnityEngine;
using System.Collections;

public class PortalCheck : MonoBehaviour
{
	[SerializeField] bool isRedPortal = false; // Set this to true only for the Red Portal
	[SerializeField] bool isBluePortal = false; // Set this to true only for the Blue Portal

	[SerializeField] PortalCheck otherPortalCheck;
	[SerializeField] GameObject levelCompleteMessage;
	[SerializeField] Animator redPlayerAnimator;
	[SerializeField] Animator bluePlayerAnimator;
	[SerializeField] LevelManagerScript levelManager;

	private static bool redPlayerFaded;
	private static bool bluePlayerFaded;
	private static bool hasLevelCompleted;
	private float deathDelay = 1.4f; // Delay before the player is destroyed

	public void Start()
	{
		redPlayerFaded = false;
		bluePlayerFaded = false;
		hasLevelCompleted = false;

	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		// Check if the Red Player enters the Red Portal
		if (isRedPortal && collision.CompareTag("Red") && !redPlayerFaded)
		{
			redPlayerAnimator.SetTrigger("Fadeout");
			StartCoroutine(FadeOutPlayer("Red"));
		}
		// Check if the Blue Player enters the Blue Portal
		else if (isBluePortal && collision.CompareTag("Blue") && !bluePlayerFaded)
		{
			bluePlayerAnimator.SetTrigger("Fadeout");
			StartCoroutine(FadeOutPlayer("Blue"));
		}
		// Wrong player enters the portal - trigger death actions
		else if (isRedPortal && collision.CompareTag("Blue")) // Blue player enters Red portal
		{
			TriggerDeath(collision.gameObject);
		}
		else if (isBluePortal && collision.CompareTag("Red")) // Red player enters Blue portal
		{
			TriggerDeath(collision.gameObject);
		}
	}

	private IEnumerator FadeOutPlayer(string playerTag) // Player fade out animation
	{
		float fadeOutDuration = 1.0f;
		yield return new WaitForSeconds(fadeOutDuration);

		if (playerTag == "Red")
		{
			redPlayerFaded = true;
		}
		else if (playerTag == "Blue")
		{
			bluePlayerFaded = true;
		}

		CheckLevelCompletion();
	}

	private void CheckLevelCompletion() // Check if players have faded after entering portal, triggering level complete message
	{
		if (redPlayerFaded && bluePlayerFaded && !hasLevelCompleted)
		{
			CompleteLevel();
		}
	}

	private void CompleteLevel() // Display level complete message
	{
		hasLevelCompleted = true;
		Debug.Log("Level 1 complete!");

		levelCompleteMessage.SetActive(true);
	  
	}

	private void TriggerDeath(GameObject player)
	{
		Debug.Log(player.name + " entered the wrong portal and died!");

		// Get the Animator and Movement components from the player
		Animator playerAnimator = player.GetComponent<Animator>();
		playerMovement playerMove = player.GetComponent<playerMovement>();

		// Trigger the death animation
		playerAnimator.SetBool("isDead", true);

		// Disable player movement
		playerMove.isAbleToMove = false;
  

		// Destroy the player GameObject after the delay
		StartCoroutine(DestroyPlayer(player, deathDelay));
	}

	private IEnumerator DestroyPlayer(GameObject player, float delay)
	{
		yield return new WaitForSeconds(delay);
		Destroy(player); // Destroy the player GameObject after the delay
		levelManager.gameOver();
	}
}
