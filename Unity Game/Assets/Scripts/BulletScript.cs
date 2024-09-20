using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;

    private GameObject player;
    [SerializeField] float bulletLifeTime = 2f;
    // [SerializeField] string nameOfPlayer = "NULL";

    // Start is called before the first frame update
    void Start()
    {
        // player = GameObject.FindWithTag(nameOfPlayer);
        rb = GetComponent<Rigidbody2D>();
        if (player.transform.localScale.x > 0)
        {
            rb.velocity = transform.right * speed;
        }
        else if (player.transform.localScale.x < 0)
        {
            rb.velocity = -transform.right * speed;
        }
        Destroy(gameObject, bulletLifeTime);
    }

    public void SetPlayer (GameObject player)
    {
        this.player = player;
    }
}
