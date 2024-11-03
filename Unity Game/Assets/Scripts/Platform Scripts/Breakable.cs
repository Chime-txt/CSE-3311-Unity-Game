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
        if (collision.gameObject.tag.Equals("RedBullet") && gameObject.tag.Equals("Blue"))// if the bullet from the Red Player collides with a Blue object, both are destroyed
        {
            DestroyBlock(collision);
        }
        else if (collision.gameObject.tag.Equals("BlueBullet") && gameObject.tag.Equals("Red")) // if the bullet from the Blue Player collides with a Red object, both are destroyed
        {
            DestroyBlock(collision);
        }
        else if ((collision.gameObject.tag.Equals("RedBullet") || collision.gameObject.tag.Equals("BlueBullet")) && gameObject.tag.Equals("Purple")) // if a bullet from the Red or Blue Player collides with a Purple object, both are destroyed
        {
            DestroyBlock(collision);
        }
    }

    private void DestroyBlock(Collision2D collision)
    {
        GameObject ParticleEffect = Instantiate(particles, transform.position, transform.rotation);
        Destroy(collision.gameObject);
        Destroy(gameObject, .2f);
        Destroy(ParticleEffect, 1f);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
