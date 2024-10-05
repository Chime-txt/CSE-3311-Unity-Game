using UnityEngine;

public class PortalCheck : MonoBehaviour
{
    public bool isRedPlayerInRedPortal = false;
    public bool isBluePlayerInBluePortal = false;

    public PortalCheck portalCheck;

    // Reference to your Level Complete UI or message
    public GameObject levelCompleteMessage;

    // This method gets called when a player enters a portal's trigger collider
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if this portal is the Red Portal
        if (collision.gameObject.tag.Equals("Red") && gameObject.tag.Equals("RedNext"))
        {
            isRedPlayerInRedPortal = true;
            portalCheck.isRedPlayerInRedPortal = true;
        }
        // Check if this portal is the Blue Portal
        else if (collision.gameObject.tag.Equals("Blue") && gameObject.tag.Equals("BlueNext"))
        {
            isBluePlayerInBluePortal = true;
            portalCheck.isBluePlayerInBluePortal = true;

        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        // Check if this portal is the Red Portal
        if (collision.gameObject.tag.Equals("Red"))
        {
            isRedPlayerInRedPortal = false;
            portalCheck.isRedPlayerInRedPortal = false;

        }
        // Check if this portal is the Blue Portal
        else if (collision.gameObject.tag.Equals("Blue"))
        {
            isBluePlayerInBluePortal = false;
            portalCheck.isBluePlayerInBluePortal = false;

        }

    }
    private void Update()
    {
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

