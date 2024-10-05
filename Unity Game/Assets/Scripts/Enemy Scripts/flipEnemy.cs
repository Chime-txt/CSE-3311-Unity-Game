using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flipEnemy : MonoBehaviour
{
    private bool isFacingRight = true;
    public float speed = 2f; // Speed of enemy movement
    public float movementRange = 5f; // Range from the center position
    private float leftBoundary, rightBoundary;

    // Start is called before the first frame update
    void Start()
    {
        // Set the center as the initial position
        float center = transform.position.x;
        leftBoundary = center - movementRange;
        rightBoundary = center + movementRange;
    }

    // Update is called once per frame
    void Update()
    {
        MoveEnemy();
        FlipMethod();
    }

    private void MoveEnemy()
    {
        // Move the enemy horizontally
        float moveDirection = isFacingRight ? 1 : -1;
        transform.Translate(Vector2.right * moveDirection * speed * Time.deltaTime);
    }

    private void FlipMethod()
    {
        if (isFacingRight && transform.position.x >= rightBoundary)
        {
            Flip(); // Flip when reaching the right boundary
        }
        else if (!isFacingRight && transform.position.x <= leftBoundary)
        {
            Flip(); // Flip when reaching the left boundary
        }
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f; // Flip the sprite
        transform.localScale = localScale;
    }
}
