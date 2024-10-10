using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// ChangeSceneScript changes the scene using the Unity Scene Management
public class ChangeSceneScript : MonoBehaviour
{
    // The scene must first be included in the build settings before the script can change scenes

    
    // To run this function, there will be a specific amount of UI Buttons (Start Game, Main Menu
    // Restart, Level Select, Level) that will make this function run based on the scene that we
    // pass into this function from a text field in the Button's On Click function in Unity
    public void ChangingScenes(string sceneName)
    {
        // Load any scene using scene name (uses one function and we can edit this value in Unity
        // and ensures consistency)
        SceneManager.LoadScene(sceneName);
        // For debugging purposes, we print the new scene name into the console
        Debug.Log("Scene Changed To " + sceneName);
    }
}
