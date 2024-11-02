using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManagerScript : MonoBehaviour
{
	[SerializeField] GameObject gameOverUI;
	[SerializeField] GameObject pauseMenuUI;
	[SerializeField] GameObject pauseButtonUI;

	// The state of the player object is one way to determine the state of the level manager 
	[SerializeField] GameObject playersObject;

	// Start is called before the first frame update
	void Start()
	{
		// Resume in-game speed (1) (redundancy due to ChangeSceneScript.cs)
		setGameSpeed(1);

		// TODO: Be able to take the user input of ESC or their respective Pause button
		//       to pause the game

		// When game starts, the cursor will not be visible and is locked so it
		// will not interact with the game
		// Cursor.visible = false;
		// Cursor.lockState = CursorLockMode.Locked;

		Debug.Log("> Level Start");
	}

	// Update is called once per frame
	void Update()
	{
		
	}

	// FixedUpdate is called once per a fixed amount of frames
	private void FixedUpdate()
	{
		// This if conditional causes the cursor to appear and be able to move
		// To trigger this conditional, it requires the game over screen to appear
		if (gameOverUI.activeInHierarchy)
		{
			// Enables the cursor to appear
			// Cursor.visible = true;

			// Enables the cursor to move around
			// Cursor.lockState = CursorLockMode.None;
		}
		else
		{
			// This else conditional disables the cursor from being seen during gameplay
			// Disable the cursor from being seen
			// Cursor.visible = false;

			// Disable the cursor from move
			// Cursor.lockState = CursorLockMode.Locked;
		}
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

			// Disable one or both players (if present) in the Players Object
			playersObject.SetActive(false);

			// Enable the pause menu and disable the in-game pause button
			pauseMenuUI.SetActive(true);
			pauseButtonUI.SetActive(false);

			Debug.Log("> Paused");
		}
		else if (pauseMenuUI.activeInHierarchy)
		{
			// Resume in-game speed (1)
			setGameSpeed(1);

			// Enable one or both players (if present) in the Players Object
			playersObject.SetActive(true);

			// Disable the pause menu and enable the in-game pause button
			pauseMenuUI.SetActive(false);
			pauseButtonUI.SetActive(true);

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

		// Disable all pause menu related UI
		pauseButtonUI.SetActive(false);
		pauseMenuUI.SetActive(false);

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
