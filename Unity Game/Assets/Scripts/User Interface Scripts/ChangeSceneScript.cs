using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// ChangeSceneScript changes the scene using the Unity Scene Management
public class ChangeSceneScript : MonoBehaviour
{
	[SerializeField] GameObject audioFile;
	[SerializeField] AudioClip audioClip;

    // The scene must first be included in the build settings before the script can change scenes

    // This function changes from the current scene to the dedicated scene with the scene name
    // To trigger this function, one of the listed UI Buttons (Start Game, Main Menu Level Select, Level)
    // has to be pressed and then selected
    public void ChangingScenes(string sceneName)
	{
        if (audioFile != null)
        {
            DontDestroyOnLoad(audioFile);
        }
        if (string.IsNullOrEmpty(sceneName))
		{
			// There was no level to load, instead, load main menu
			Debug.Log("Scene name was not added to " + gameObject.name + "... Loading Main Menu...");
			sceneName = "MainMenu";
		}
		
		// Load any scene using scene name (uses one function and we can edit this value in Unity
		// and ensures consistency)
		SceneManager.LoadScene(sceneName);
		
		// Resume in-game speed (1)
		Time.timeScale = 1;
		
		// For debugging purposes, we print the new scene name into the console
		Debug.Log("Scene Changed To " + sceneName);
	}

	// This function is dedicated to the Next Level button which moves to the next level while
	// also saving the progress of the user who has reached a certain level
	public void NextLevel(string sceneName)
	{
        if (audioFile != null)
        {
            DontDestroyOnLoad(audioFile);
        }
        // This function will then change scenes, given the name of the scene in the next level button
        ChangingScenes(sceneName);
	}

	// This function is dedicated to the Restart UI button which restarts the level with the
	// current build index
	// To trigger this function, the Restart button has to be pressed and then selected
	public void RestartLevel()
	{

        if (audioFile != null)
        {
            DontDestroyOnLoad(audioFile);
        }
        // Loads the same level using the build index
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	// This function is dedicated to the Quit UI button which quits the application
	// To trigger this function, the Quit button has to be pressed and then selected
	// before the game closes
	public void QuitGame()
	{
		Debug.Log("Quitting Game...");
		Application.Quit();
	}
    // Start is called before the first frame update
    void Start()
    {
        audioFile = FindFirstObjectByType<AudioSource>().gameObject;
    }

}
