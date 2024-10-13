using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// ChangeSceneScript changes the scene using the Unity Scene Management
public class ChangeSceneScript : MonoBehaviour
{
	// The scene must first be included in the build settings before the script can change scenes

	// This function changes from the current scene to the dedicated scene with the scene name
	// To trigger this function, one of the listed UI Buttons (Start Game, Main Menu Level Select, Level)
	// has to be pressed and then selected
	public void ChangingScenes(string sceneName)
	{
		// Load any scene using scene name (uses one function and we can edit this value in Unity
		// and ensures consistency)
		SceneManager.LoadScene(sceneName);

		// Resume in-game speed (1)
		Time.timeScale = 1;

		// For debugging purposes, we print the new scene name into the console
		Debug.Log("Scene Changed To " + sceneName);
	}

	// This function is dedicated to the Restart UI button which restarts the level with the
	// current build index
	// To trigger this function, the Restart button has to be pressed and then selected
	public void RestartLevel()
	{
		// Loads the same level using the build index
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}
