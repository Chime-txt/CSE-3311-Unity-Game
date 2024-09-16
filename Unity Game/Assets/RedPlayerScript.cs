using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedPlayerScript : MonoBehaviour
{
    public Rigidbody2D PlayerRedRigid;
    public float moveSpeed;
    public float jumpPower;
    public float moveRate = 0.5f;
    private float timer = 0;
    [SerializeField] private bool groundCollision;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < moveRate)
        {
            timer = timer + Time.deltaTime;
        }
        else if ((Input.GetKey(KeyCode.A) == true) || (Input.GetKey(KeyCode.D) == true)) {
            horizontalMovement();
        }
        if (Input.GetKeyDown(KeyCode.W) == true)
        {
            PlayerRedRigid.velocity = Vector2.up * jumpPower;
        }
    }

    public void horizontalMovement()
    {
        if (Input.GetKey(KeyCode.A) == true)
        {
            if (Input.GetKeyDown(KeyCode.A) == true)
            {
                Debug.Log("Moving with A key");
            }
            PlayerRedRigid.velocity = Vector2.left * moveSpeed;
        }
        if (Input.GetKey(KeyCode.D) == true)
        {
            if (Input.GetKeyDown(KeyCode.D) == true)
            {
                Debug.Log("Moving with D key");
            }
            PlayerRedRigid.velocity = Vector2.right * moveSpeed;
        }
        
    }

    private void onGround()
    {

    }
}
