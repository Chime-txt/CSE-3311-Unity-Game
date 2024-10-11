using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerDeaths : MonoBehaviour
{
    [SerializeField] float timeTillDeath = 1.4f;
    public Animator animator;
    playerMovement playerMove;

    //
    public LevelManagerScript levelManager;

    // Start is called before the first frame update
    void Start()
    {
        playerMove = GetComponent<playerMovement>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("RedEnemy") && gameObject.tag.Equals("Blue") )// if the player collides with RedEnemy
        {
            KillPlayer();
        }
        else if (collision.gameObject.tag.Equals("BlueEnemy") && gameObject.tag.Equals("Red")) // if the player collides with RedEnemy
        {
            KillPlayer();
        }
        else if (collision.gameObject.tag.Equals("Purple")) // if the player collides with PurpleEnemy
        {
            KillPlayer();
        }
    }
    
    // This function kills the current player and triggers the game over screen
    // To make this function run, the player has to collide with other enemies of different colors
    private void KillPlayer()
    {
        Debug.Log("A player is dead");

        // Disable player movement
        playerMove.isAbleToMove = false;

        // Call a coroutine to play the death animation 
        StartCoroutine(DeathAnimation());

        IEnumerator DeathAnimation()
        {
            // Play the character death animation
            animator.SetBool("isDead", true);
    
            // Destroys the character
            Destroy(gameObject, timeTillDeath);

            // Waits for the current player to finish its death animation
            yield return new WaitForSeconds(1.4f);

            // Trigger the game over function
            levelManager.gameOver();
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
