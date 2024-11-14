using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// ChangeSceneScript changes the scene using the Unity Scene Management
public class ChangeSceneScript : MonoBehaviour
{
    // The scene must first be included in the build settings before the script can change scenes
    [Header("Vars for Next Level")]
    bool isOnLastLevel = false;
    public int nextSceneLoad;
    int lastScene = 8;
	public GameObject redSlime;
	public GameObject blueSlime;
	private PortalCheck redPortal, bluePortal;

    private void Start()
    {
        nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;

        redSlime = GameObject.FindGameObjectWithTag("Red");
		blueSlime = GameObject.FindGameObjectWithTag("Blue");
		redPortal = redSlime.GetComponent<PortalCheck>();
		bluePortal = blueSlime.GetComponent<PortalCheck>();
	}

    // This function changes from the current scene to the dedicated scene with the scene name
    // To trigger this function, one of the listed UI Buttons (Start Game, Main Menu Level Select, Level)
    // has to be pressed and then selected
    public void ChangingScenes(string sceneName)
	{
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

	// Abu, put the code from the Portal Check into this script
	public void NextLevel(string sceneName)
	{
		// Do not load the next scene as the function above does it, but if you need to, add your code to both functions.
		MoveToNextLevel();

		// This function will then change scenes, given the name of the scene in the next level button.
		ChangingScenes(sceneName);
	}

	// This function is dedicated to the Restart UI button which restarts the level with the
	// current build index
	// To trigger this function, the Restart button has to be pressed and then selected
	public void RestartLevel()
	{
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
	private void MoveToNextLevel()
    {
        if (redPortal.redPlayerFaded && bluePortal.bluePlayerFaded)
        {
            if (SceneManager.GetActiveScene().buildIndex == lastScene && isOnLastLevel == false)
            {
                isOnLastLevel = true;
                Debug.Log("YOU WIN");

            }
            else
            {
                ////Move to Next Level
                //SceneManager.LoadScene(nextSceneLoad);
                //Debug.Log("MOVING TO NEXT LEVEL");

                if (nextSceneLoad > PlayerPrefs.GetInt("levelAt"))
                {
                    //Debug.Log("PlayerPref = " + PlayerPrefs.GetInt("levelAt"));
                    PlayerPrefs.SetInt("levelAt", nextSceneLoad);
                    //Debug.Log("Setting PlayerPref levelAt to: " + nextSceneLoad);
                }
            }

        }
    }
}
