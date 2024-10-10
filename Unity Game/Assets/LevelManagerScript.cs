using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManagerScript : MonoBehaviour
{
    public GameObject gameOverUI;
    public GameObject pauseMenuUI;
    public GameObject pauseButtonUI;

    // Start is called before the first frame update
    void Start()
    {
        // When game starts, the cursor will not be visible and is locked so it
        // will not interact with the game
        // Cursor.visible = false;
        // Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // FixedUpdate is called once per a fixed amount of frames
    private void FixedUpdate()
    {
        // This if conditional causes the cursor to appear and be able to move
        // To make this conditional run, it requires the game over screen to appear
        if (gameOverUI.activeInHierarchy)
        {
            // Enables the cursor to appear
            Cursor.visible = true;
            // Enables the cursor to move around
            Cursor.lockState = CursorLockMode.None;
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

    // The functions below are related to the pause menu overlay

    // This function causes the pause menu overlay to appear
    // To make this function run, it requires the player to (click the pause button)
    // Later change this to the ESC (Escape) key
    public void isPaused()
    {
        if (!pauseMenuUI.activeInHierarchy)
        {
            pauseMenuUI.SetActive(true);
            pauseButtonUI.SetActive(false);
            Debug.Log("> Paused");
        }
        else if (pauseMenuUI.activeInHierarchy)
        {
            pauseMenuUI.SetActive(false);
            pauseButtonUI.SetActive(true);
            Debug.Log("> Unpaused");
        }
    }

    // The functions below are related to the game over screen

    // This function causes the game over screen to appear
    // To make this function run, it requires the player to die.
    public void gameOver()
    {
        // Disable all pause menu related UI
        pauseButtonUI.SetActive(false);
        pauseMenuUI.SetActive(false);   // This is temporary as I haven't finished implementing how to pause the enemies and players

        // Enable game over screen UI
        gameOverUI.SetActive(true);
    }
}
