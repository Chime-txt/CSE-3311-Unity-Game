using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerDeaths : MonoBehaviour
{
    [SerializeField] float timeTillDeath = 1.4f;
    public Animator animator;
    playerMovement playerMove;

    // Death planes
    [SerializeField] GameObject deathPlanes;

    // The level manager controls the UI elements
    public LevelManagerScript levelManager;

    // Start is called before the first frame update
    void Start()
    {
        playerMove = GetComponent<playerMovement>();
    }

    // This function detects whether the player has collided with any enemy type before killing the player
    // To trigger this function, the player has to touch the enemy of a different color
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("RedEnemy") && gameObject.tag.Equals("Blue") )// If the player collides with RedEnemy
        {
            KillPlayer();
        }
        else if (collision.gameObject.tag.Equals("BlueEnemy") && gameObject.tag.Equals("Red")) // If the player collides with RedEnemy
        {
            KillPlayer();
        }
        else if (collision.gameObject.tag.Equals("Purple")) // If the player collides with PurpleEnemy
        {
            KillPlayer();
        }
    }

    // This function detects whether the player has passed through the death plane before killing the player
    // To trigger this function, the player has to enter the death plane
    private void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.CompareTag("Death Planes")) // If player enters the Death Planes
        {
            Debug.Log("Player Died By Death Plane");

            // We could try destroying the player and trigger the game over screen
            // or we could insert some death music to play before the character dies
            // inside of the kill player function
            KillPlayer();
        }
    }

    // This function kills the current player and triggers the game over screen
    // To trigger this function, the player has to collide with other enemies of different colors
    private void KillPlayer()
    {
        Debug.Log("A Player Is Dead");

        // Disable player movement
        playerMove.isAbleToMove = false;

        // Call a coroutine to play the death animation 
        StartCoroutine(DeathAnimation());

        IEnumerator DeathAnimation()
        {
            // Play the character death animation
            animator.SetBool("isDead", true);
    
            // Waits for the current player to finish its death animation
            yield return new WaitForSeconds(timeTillDeath);

            // Destroys the character
            Destroy(gameObject);

            // Trigger the game over function
            levelManager.gameOver();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
