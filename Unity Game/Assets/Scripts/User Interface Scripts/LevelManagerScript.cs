using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManagerScript : MonoBehaviour
{
	// The state of the player object is one way to determine the state of the level manager 
	[Header("Player Management")]
	[SerializeField] GameObject playersObject;

	[Header("UI Management")]
	[SerializeField] GameObject gameOverUI;
	[SerializeField] GameObject pauseMenuUI;
	[SerializeField] GameObject pauseButtonUI;
	[SerializeField] GameObject ammoBarUI;

	// Start is called before the first frame update
	void Start()
	{
		// Resume in-game speed (1) (redundancy due to ChangeSceneScript.cs)
		setGameSpeed(1);

		Debug.Log("> Level Start");
	}

	// This function causes the pause menu overlay to appear
	// To trigger this function, it requires the player to (click the pause button)
	// Later change this to the ESC (Escape) key
	public void isPaused()
	{
		// Checks if the pause menu is active or not
		if (!pauseMenuUI.activeInHierarchy)
		{
			// Pause in-game speed (0)
			setGameSpeed(0);

			if ((playersObject != null) && (playersObject.gameObject != null))
			{
				// Disable one or both players (if present) in the Players Object
				playersObject.SetActive(false);
			}

			// Enable the pause menu
			pauseMenuUI.SetActive(true);

			Debug.Log("> Paused");
		}
		else if (pauseMenuUI.activeInHierarchy)
		{
			// Resume in-game speed (1)
			setGameSpeed(1);

			if (playersObject.gameObject != null)
			{
				// Enable one or both players (if present) in the Players Object
				playersObject.SetActive(true);
			}

			// Disable the pause menu
			pauseMenuUI.SetActive(false);

			Debug.Log("> Unpaused");
		}
	}

	// This function causes the game over screen to appear
	// To trigger this function, it requires the player to die.
	public void gameOver()
	{
		// Pause in-game speed (0)
		setGameSpeed(0);

		// Disable one or both players (if present)
		playersObject.SetActive(false);

		// Disable all other related UI besides the game over UI
		pauseButtonUI.SetActive(false);
		pauseMenuUI.SetActive(false);
		ammoBarUI.SetActive(false);

		// Enable game over screen UI
		gameOverUI.SetActive(true);

		Debug.Log("> Game Over");
	}

	// This function sets the game speed when necessary
	// To trigger this function, it requires the user to trigger the game over screen
	// or trigger the pause menu overlay (or start the level, which is redundant)
	protected static void setGameSpeed(int gameSpeed)
	{
		Time.timeScale = gameSpeed;
	}
}
