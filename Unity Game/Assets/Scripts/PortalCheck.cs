using UnityEngine;

public class PortalCheck : MonoBehaviour
{
    private bool isRedPlayerInRedPortal = false;
    private bool isBluePlayerInBluePortal = false;

    // Reference to your Level Complete UI or message
    public GameObject levelCompleteMessage;

    // This method gets called when a player enters a portal's trigger collider
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if this portal is the Red Portal
        if (collision.gameObject.tag.Equals("Red"))
        {
            isRedPlayerInRedPortal = true;
        }
        // Check if this portal is the Blue Portal
        else if (collision.gameObject.tag.Equals("Blue"))
        {
            isBluePlayerInBluePortal = true;
        }

        // Check if both players are in their respective portals
        if (isRedPlayerInRedPortal && isBluePlayerInBluePortal)
        {
            CompleteLevel();
        }
    }

    /*// This method gets called when a player exits the portal's trigger collider
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (gameObject.CompareTag("RedPortal") && collision.gameObject.tag.Equals("Red"))
        {
            isRedPlayerInRedPortal = false;
        }
        else if (gameObject.CompareTag("BluePortal") && collision.gameObject.tag.Equals("Blue"))
        {
            isBluePlayerInBluePortal = false;
        }
    }*/

    // This method handles level completion when both players are in the correct portals
    private void CompleteLevel()
    {
        Debug.Log("Level 1 complete!");
        if (levelCompleteMessage != null)
        {
            levelCompleteMessage.SetActive(true);
        }
    }
}

