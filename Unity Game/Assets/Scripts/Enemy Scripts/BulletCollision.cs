using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Permissions;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Bullet collision with an Enemy
        if (collision.gameObject.tag.Equals("RedBullet") && gameObject.tag.Equals("BlueEnemy"))// if the bullet from the Red Player collides with a BlueEnemy, both are destroyed
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag.Equals("BlueBullet") && gameObject.tag.Equals("RedEnemy")) // if the bullet from the Blue Player collides with a RedEnemy, both are destroyed
        {
            {
                Destroy(collision.gameObject);
                Destroy(gameObject);
            }
        }
        else if ((collision.gameObject.tag.Equals("RedBullet") || collision.gameObject.tag.Equals("BlueBullet")) && gameObject.tag.Equals("Purple")) // if a bullet from the Red or Blue Player collides with a Purple enemy, both are destroyed
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        }
        // Update is called once per frame
        void Update()
        {

        }
   }
