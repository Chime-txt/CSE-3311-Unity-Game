using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }
    public GameObject particles;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("RedBullet") && gameObject.tag.Equals("Blue"))// if the player collides with RedEnemy
        {
            Instantiate(particles, transform.position, transform.rotation);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag.Equals("BlueBullet") && gameObject.tag.Equals("Red")) // if the player collides with RedEnemy
        {
            Instantiate(particles, transform.position, transform.rotation);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        else if ((collision.gameObject.tag.Equals("RedBullet") || collision.gameObject.tag.Equals("BlueBullet")) && gameObject.tag.Equals("Purple")) // if the player collides with PurpleEnemy
        {
            Instantiate(particles, transform.position, transform.rotation);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
