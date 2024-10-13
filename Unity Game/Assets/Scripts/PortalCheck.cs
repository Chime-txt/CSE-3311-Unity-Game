using UnityEngine;
using System.Collections;

public class PortalCheck : MonoBehaviour
{
    // Indicates whether this is the red portal
    public bool isRedPortal = false;

    // Reference to the other portal's script
    public PortalCheck otherPortalCheck;

    // GameObject that will display the "Level Complete" message
    public GameObject levelCompleteMessage;

    // Animator components for the red and blue players to trigger fade-out animations
    public Animator redPlayerAnimator;
    public Animator bluePlayerAnimator;

    // Static variables to track whether each player has completed the fade-out animation
    private static bool redPlayerFaded = false;
    private static bool bluePlayerFaded = false;

    // Ensures the level is completed only once
    private static bool hasLevelCompleted = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If the red player enters the red portal and has not yet faded out
        if (isRedPortal && collision.gameObject.tag.Equals("Red") && !redPlayerFaded)
        {
            // Trigger red player's fade-out animation
            redPlayerAnimator.SetTrigger("Fadeout");

            // Start coroutine to wait for fade-out animation to complete
            StartCoroutine(FadeOutPlayer("Red"));
        }

        // If the blue player enters the blue portal and has not yet faded out
        else if (!isRedPortal && collision.gameObject.tag.Equals("Blue") && !bluePlayerFaded)
        {
            // Trigger blue player's fade-out animation
            bluePlayerAnimator.SetTrigger("Fadeout");

            // Start coroutine to wait for fade-out animation to complete
            StartCoroutine(FadeOutPlayer("Blue"));
        }
    }

    // Function to handle player fade-out
    private IEnumerator FadeOutPlayer(string playerTag)
    {
        // Duration of the fade-out animation
        float fadeOutDuration = 1.0f;

        // Wait for animation to finish
        yield return new WaitForSeconds(fadeOutDuration);

        // Set the respective player's faded flag to true
        if (playerTag == "Red")
        {
            redPlayerFaded = true;
        }
        else if (playerTag == "Blue")
        {
            bluePlayerFaded = true;
        }

        // Check if both players have faded out and trigger level completion
        CheckLevelCompletion();
    }

    // Function to check if both players have faded out and complete the level
    private void CheckLevelCompletion()
    {
        if (redPlayerFaded && bluePlayerFaded && !hasLevelCompleted)
        {
            CompleteLevel();
        }
    }

    // Function to handle the completion of the level
    private void CompleteLevel()
    {
        // Set the flag to indicate the level is completed
        hasLevelCompleted = true;
        Debug.Log("Level 1 complete!");

        // Activate the level complete message
        if (levelCompleteMessage != null)
        {
            levelCompleteMessage.SetActive(true);
        }
    }
}
