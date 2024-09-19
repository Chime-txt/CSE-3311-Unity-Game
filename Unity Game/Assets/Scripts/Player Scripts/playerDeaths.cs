using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerDeaths : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("RedEnemy") && gameObject.tag.Equals("Blue") )// if the player collides with RedEnemy
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag.Equals("BlueEnemy") && gameObject.tag.Equals("Red")) // if the player collides with RedEnemy
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag.Equals("Purple")) // if the player collides with PurpleEnemy
        {
            Debug.Log("Player Destroyed");
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
