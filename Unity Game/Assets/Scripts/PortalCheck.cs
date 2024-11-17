using UnityEngine;
using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine.SceneManagement;

public class PortalCheck : MonoBehaviour
{
	[Header("Portal Check")]
	[SerializeField] PortalCheck otherPortalCheck;
	[SerializeField] bool isRedPortal = false; // Set this to true only for the Red Portal
	[SerializeField] bool isBluePortal = false; // Set this to true only for the Blue Portal
	[SerializeField] bool playerAtPortal = false;
	[SerializeField] bool completeLock = false;

	[Header("Player Management")]
	[SerializeField] Animator redPlayerAnimator;
	[SerializeField] Animator bluePlayerAnimator;

	[Header("Level Manager")]
	[SerializeField] LevelManagerScript levelManager;

	[Header("UI Management")]
	[SerializeField] GameObject levelCompleteMessage;

	[Header("Vars for Next Level")]
	bool isOnLastLevel = false;
	public int nextSceneLoad;
	int lastScene = 8;

	private static bool redPlayerFaded;
	private static bool bluePlayerFaded;
	private static bool hasLevelCompleted;
	private float deathDelay = 1.4f; // Delay before the player is destroyed

    [Header("Audio Management")]
    [SerializeField] AudioClip audioclip;
    [SerializeField] AudioSource audioSource;

    void Start()
	{ 
        audioSource = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>();

        redPlayerFaded = false;
		bluePlayerFaded = false;
		hasLevelCompleted = false;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		// Check if the Red Player enters the Red Portal
		if (isRedPortal && collision.CompareTag("Red") && !redPlayerFaded)
		{
			playerAtPortal = true;

			StartCoroutine(CheckWinConditions("Red", collision));
		}
		// Check if the Blue Player enters the Blue Portal
		else if (isBluePortal && collision.CompareTag("Blue") && !bluePlayerFaded)
		{
			// Indicates that the player is at their portal
			playerAtPortal = true;

			StartCoroutine(CheckWinConditions("Blue", collision));
		}
		// Wrong player enters the portal - trigger death actions
		else if (isRedPortal && collision.CompareTag("Blue") && !completeLock) // Blue player enters Red portal
		{
			TriggerDeath(collision.gameObject);
		}
		else if (isBluePortal && collision.CompareTag("Red") && !completeLock) // Red player enters Blue portal
		{
			TriggerDeath(collision.gameObject);
		}
	}

	// If the player leaves the portal at any time before the other player reaches their respective
	// portal, this function sets their flag at the portal to false
	private void OnTriggerExit2D(Collider2D collision)
	{
		// Indicates that the player is not at their portal
		playerAtPortal = false;
	}

	private IEnumerator CheckWinConditions(string playerTag, Collider2D collision)
	{
		Debug.Log(playerTag + " Entered Their Portal");

		while (playerAtPortal && !completeLock)
		{
			// Check if the other portal is active and enabled
			// and if the other player is at their portal
			// and if lock is taken (to prevent retriggering the function)
			if (otherPortalCheck.isActiveAndEnabled && otherPortalCheck.playerAtPortal && !completeLock)
			{
				// Set the lock when both players reached their respective portals
				completeLock = true;

				if (playerTag == "Red")
				{
					// Play the fade out animation for the red player
					redPlayerAnimator.SetTrigger("Fadeout");
					audioSource.PlayOneShot(audioclip);
					StartCoroutine(FadeOutPlayer("Red", collision));
				}
				if (playerTag == "Blue")
				{
					// Play the fade out animation for the blue player
					bluePlayerAnimator.SetTrigger("Fadeout");
                    audioSource.PlayOneShot(audioclip);
                    StartCoroutine(FadeOutPlayer("Blue", collision));
				}
			}
			yield return new WaitForFixedUpdate();
		}
	}

	private IEnumerator FadeOutPlayer(string playerTag, Collider2D collision) // Player fade out animation
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

		// Disable the Player who faded
		collision.gameObject.SetActive(false);

		CheckLevelCompletion();
	}

	private void CheckLevelCompletion() // Check if players have faded after entering portal, triggering level complete message
	{
		if (redPlayerFaded && bluePlayerFaded && !hasLevelCompleted)
		{
			// Perform an update on the save file
			MoveToNextLevel();

			// Toggle on the Level Complete Screen
			CompleteLevel();
		}
	}

	// This function was created by Abubakar
	private void MoveToNextLevel()
	{
		Debug.Log("In MoveToNextLevel function");
		if (SceneManager.GetActiveScene().buildIndex == lastScene && isOnLastLevel == false)
		{
			isOnLastLevel = true;
			Debug.Log("YOU WIN");

		}
		else if (nextSceneLoad > PlayerPrefs.GetInt("levelAt"))
		{
			// Save the next level into the save file
			nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;

			// Update the vale of the build to the save file
			Debug.Log("PlayerPref = " + PlayerPrefs.GetInt("levelAt"));
			PlayerPrefs.SetInt("levelAt", nextSceneLoad);
			Debug.Log("Setting PlayerPref levelAt to: " + nextSceneLoad);
		}
	}

	private void CompleteLevel() // Display level complete message
	{
		hasLevelCompleted = true;
		Debug.Log("Level complete!");

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
