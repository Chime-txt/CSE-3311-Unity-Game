using UnityEngine;

public class PlayerPlatformSync : MonoBehaviour
{
    private Transform originalParent; // Store the player's original parent



    /*
     * The reason for this script is because the if the player were to land on a moving platform and that platforms begins to move 
     * the player will not because the movingPlatform script moves itself only. By making the player a child of the platform they will
     * both move when the platform moves.
     */
    void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("Able to get triggered");
        //Debug.Log(collision.gameObject.name);

        // Check if the player has collided with a moving platform
        if (collision.gameObject.CompareTag("MovingPlatform"))
        {
            Debug.Log("On a Platfrom");

            // Store the original parent of the player
            originalParent = transform.parent;

            // Make the player a child of the platform to move with it
            transform.SetParent(collision.transform);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        // First check if the player is visible in the hierarchy
        if (collision.gameObject.activeInHierarchy)
        {
		    // Check if the player is leaving the moving platform
		    if (collision.gameObject.CompareTag("MovingPlatform"))
            {
                // Detach the player from the platform and restore the original parent
                transform.SetParent(originalParent);
            }
        }
    }
}
