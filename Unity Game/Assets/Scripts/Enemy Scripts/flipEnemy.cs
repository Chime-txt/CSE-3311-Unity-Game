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

	// This function makes the enemy move horizontally
	// The game is automatically executing this function every frame 
	private void MoveEnemy()
	{
		// Move the enemy horizontally
		float moveDirection = isFacingRight ? 1 : -1;
		transform.Translate(Vector2.right * moveDirection * speed * Time.deltaTime);
	}

	// This function makes the enemy decide whether the character should
	// change direction
	// The game is automatically executing this function every frame 
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

	// This function makes the enemy change direction
	// To trigger this function, the FlipMethod function must
	// determine that the character should flip
	private void Flip()
	{
		isFacingRight = !isFacingRight;
		Vector3 localScale = transform.localScale;
		localScale.x *= -1f; // Flip the sprite
		transform.localScale = localScale;
	}
}
