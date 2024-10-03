using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// ChangeSceneScript changes the scene using the Unity Scene Management
public class ChangeSceneScript : MonoBehaviour
{
    // The scene must first be included in the build settings before the script can change scenes

    // Load any scene using scene name (uses one function and we can edit this value in Unity and
    // ensures consistency)
    public void ChangingScenes(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
