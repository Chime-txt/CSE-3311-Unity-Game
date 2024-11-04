using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Permissions;
using TMPro;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    [SerializeField] private float StunTime = 5f;
    private bool isStun = false;
    private Rigidbody2D rb;
    private flipEnemy flipEnemyScript;
    private OscillatingPlatform oscillatingPlatformScript;
    private string originalTag;
    private BoxCollider2D boxCollider;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        flipEnemyScript = GetComponent<flipEnemy>();
        oscillatingPlatformScript = GetComponent<OscillatingPlatform>();
        originalTag = gameObject.tag;
        boxCollider = GetComponent<BoxCollider2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Bullet collision with an Enemy
        if (collision.gameObject.tag.Equals("RedBullet") && gameObject.tag.Equals("BlueEnemy"))// if the bullet from the Red Player collides with a BlueEnemy, both are destroyed
        {
            Destroy(collision.gameObject);
            StartCoroutine(Stun());
        }
        else if (collision.gameObject.tag.Equals("BlueBullet") && gameObject.tag.Equals("RedEnemy")) // if the bullet from the Blue Player collides with a RedEnemy, both are destroyed
        {
            {
                Destroy(collision.gameObject);
                StartCoroutine(Stun());
            }
        }
        else if ((collision.gameObject.tag.Equals("RedBullet") || collision.gameObject.tag.Equals("BlueBullet")) && gameObject.tag.Equals("Purple")) // if a bullet from the Red or Blue Player collides with a Purple enemy, both are destroyed
        {
            Destroy(collision.gameObject);
            StartCoroutine(Stun());
        }
    }
    private IEnumerator Stun()
    {
        if (!isStun)
        {
            isStun = true;


            // Stun enemy movement
            rb.velocity = Vector2.zero;
            rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
            gameObject.tag = "Stunned";

            Vector3 originalposition = transform.position;

            // Disable movement script
            if (flipEnemyScript != null)
            {
                flipEnemyScript.enabled = false;
            }
            /*
             if (oscillatingPlatformScript != null)
            {
                oscillatingPlatformScript.isMoving = false;
            }
            */

            // Turn off collision
            if (boxCollider != null)
            {
                boxCollider.enabled = false;
            }

            // Wait for the stun duration
            yield return new WaitForSeconds(StunTime);

            // Re-enable movement script
            if (flipEnemyScript != null)
            {
                flipEnemyScript.enabled = true;
            }
            /*
            if (oscillatingPlatformScript != null)
            {
                oscillatingPlatformScript.isMoving = true;
            }
            */
            // Turn on collision
            if (boxCollider != null)
            {
                boxCollider.enabled = true;
            }

            rb.constraints = RigidbodyConstraints2D.None;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;

            gameObject.tag = originalTag;

            isStun = false;
        }
    }
    // Update is called once per frame
    void Update()
        {

        }
   }
