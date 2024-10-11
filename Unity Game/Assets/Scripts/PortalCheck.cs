using UnityEngine;
using System.Collections;

public class PortalCheck : MonoBehaviour
{
    public bool isRedPortal = false;

    public PortalCheck otherPortalCheck;

    public GameObject levelCompleteMessage;
    public Animator redPlayerAnimator;
    public Animator bluePlayerAnimator;

    private static bool redPlayerFaded = false;
    private static bool bluePlayerFaded = false;
    private static bool hasLevelCompleted = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isRedPortal && collision.gameObject.tag.Equals("Red") && !redPlayerFaded)
        {
            // Red player enters red portal
            redPlayerAnimator.SetTrigger("Fadeout");
            StartCoroutine(FadeOutPlayer("Red"));  // Start red player's fade-out
        }
        else if (!isRedPortal && collision.gameObject.tag.Equals("Blue") && !bluePlayerFaded)
        {
            // Blue player enters blue portal
            bluePlayerAnimator.SetTrigger("Fadeout");
            StartCoroutine(FadeOutPlayer("Blue"));  // Start blue player's fade-out
        }
    }

    // Handle player fade-out
    private IEnumerator FadeOutPlayer(string playerTag)
    {
        float fadeOutDuration = 1.0f;
        yield return new WaitForSeconds(fadeOutDuration);  // Wait for animation to finish

        if (playerTag == "Red")
        {
            redPlayerFaded = true;
        }
        else if (playerTag == "Blue")
        {
            bluePlayerFaded = true;
        }

        CheckLevelCompletion();
    }

    // Check if both players have faded out and complete the level
    private void CheckLevelCompletion()
    {
        if (redPlayerFaded && bluePlayerFaded && !hasLevelCompleted)
        {
            CompleteLevel();
        }
    }

    // Complete the level and display the level complete message
    private void CompleteLevel()
    {
        hasLevelCompleted = true;
        Debug.Log("Level 1 complete!");

        if (levelCompleteMessage != null)
        {
            levelCompleteMessage.SetActive(true);
        }
    }
}
