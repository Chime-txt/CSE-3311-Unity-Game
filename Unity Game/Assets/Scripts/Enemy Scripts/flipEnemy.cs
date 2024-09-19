using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flipEnemy : MonoBehaviour
{
    private bool isFacingRight = true;
    private float horizontal;

    // Start is called before the first frame update
    void Start()
    {
        horizontal = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (isFacingRight && horizontal > 0)
        {

        }
        else if (!isFacingRight && horizontal < 0)
        {

        }
    }
}
