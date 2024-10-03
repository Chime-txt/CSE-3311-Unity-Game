using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// ChangeSceneScript changes the scene using the Unity Scene Management
public class ChangeSceneScript : MonoBehaviour
{
    // Takes the scene ID from Unity and loads the scene using the scene ID
    public void MoveToScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }

    // When creating new scenes / levels, add a new function to be able to load the scene
    
    // Load TilemapTestScene
    public void LoadTilemapTestScene()
    {
        Debug.Log("Loading TilemapTestScene...");
        SceneManager.LoadScene("TilemapTestScene");
    }
}
