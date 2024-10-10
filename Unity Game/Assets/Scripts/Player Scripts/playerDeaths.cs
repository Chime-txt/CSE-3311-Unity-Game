using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerDeaths : MonoBehaviour
{
    [SerializeField] float timeTillDeath = 2f;
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

    private void KillPlayer()
    {
        Debug.Log("A player is dead");
        animator.SetBool("isDead", true);
        playerMove.isAbleToMove = false;
        Destroy(gameObject, timeTillDeath);
        levelManager.gameOver();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
