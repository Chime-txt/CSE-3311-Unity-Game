using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
	[SerializeField] float speed;
    private Rigidbody2D rb;

    private GameObject player;
    [SerializeField] float bulletLifeTime = 2f;

    // Start is called before the first frame update
    void Start()
    {
        // Assign bullet tags based on which Player shot the bullete
        if (player.tag.Equals("Red"))
        {
            gameObject.tag = "RedBullet";
        }
        if (player.tag.Equals("Blue"))
        {
            gameObject.tag = "BlueBullet";
        }

        rb = GetComponent<Rigidbody2D>();
        if (player.transform.localScale.x > 0)
        {
            rb.velocity = transform.right * speed;
        }
        else if (player.transform.localScale.x < 0)
        {
            rb.velocity = -transform.right * speed;
        }

        // Destroy the bullet after a set time
        Destroy(gameObject, bulletLifeTime);
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // If the bullet hits the ground or wall, the bullet is destroyed
        if (collision.gameObject.tag.Equals("Ground"))
        {
            Destroy(gameObject);
        }
    }
    
    // Assign bullet to Player
public void SetPlayer (GameObject player)
    {
        this.player = player;
    }
}
