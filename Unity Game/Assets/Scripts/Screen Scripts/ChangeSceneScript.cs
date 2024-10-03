using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// ChangeSceneScript changes the scene using the Unity Scene Management
public class ChangeSceneScript : MonoBehaviour
{
    // With the function below, we could layer the scenes based on the build settings

    // Takes the scene ID from Unity Build Settings and loads the scene using the scene ID
    public void MoveToScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }

    // When creating new scenes / levels, add a new function to be able to load the scene
    
    // Load TilemapTestScene using Scene Name
    public void LoadTilemapTestScene()
    {
        Debug.Log("Loading TilemapTestScene...");
        SceneManager.LoadScene("1");
    }
}
