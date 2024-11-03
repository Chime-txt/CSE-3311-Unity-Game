using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{
	[SerializeField] Rigidbody2D rb;
	[SerializeField] Transform groundCheck;
	[SerializeField] LayerMask groundLayer;
	[SerializeField] float speed = 8f;
	[SerializeField] float jumpingPower = 16f;
	[SerializeField] Animator animator;

#pragma warning disable CA1051 // Do not declare visible instance fields
	public bool isOnGround = true;
	public bool isAbleToMove = true;
#pragma warning restore CA1051 // Do not declare visible instance fields
	private float horizontal;
	private bool isFacingRight = true;

	private void FlipMethod()
	{
		if (!isFacingRight && horizontal > 0f) // If moving right
		{
			Flip(); 
		}
		else if (isFacingRight && horizontal < 0f) // If moving left
		{
			Flip();
		}
	}

	private void FixedUpdate()
	{
		if (isAbleToMove)
		{
			FlipMethod();
			IsGrounded(); // Continuously check if on ground
			rb.velocity = new Vector2(horizontal * speed, rb.velocity.y); // Ensures smooth physics
		}
	}

	public void Jump(InputAction.CallbackContext context)
	{
		if (isAbleToMove)
		{ 
			if (context.performed && isOnGround) // Use isOnGround directly
			{
				rb.velocity = new Vector2(rb.velocity.x, jumpingPower); // Jump
				isOnGround = false;
				animator.SetBool("isJumping", !isOnGround);
			}

			if (context.canceled && rb.velocity.y > 0f) // If the player is falling down
			{
				rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f); // Go down
				animator.SetBool("isJumping", false);
			}
		}
	}

	private bool IsGrounded()
	{
		bool grounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
		if (grounded)
		{
			isOnGround = true; // Make the player unable to jump
			animator.SetBool("isJumping", !isOnGround); // Don't play jumping animation
		}
		else
		{
			isOnGround = false; // Make the the player unable to jump
			animator.SetBool("isJumping", !isOnGround); // PLay jumping animation
		}
		return grounded;
	}

	private void Flip()
	{
		isFacingRight = !isFacingRight;
		Vector3 localScale = transform.localScale;
		localScale.x *= -1f; // Flip
		transform.localScale = localScale;
	}

	public void Move(InputAction.CallbackContext context)
	{
		if (isAbleToMove)
		{
			horizontal = context.ReadValue<Vector2>().x;// Move on the x axis (not needed for y-axis because it's a 2D game with gravity
		   // Debug.Log("Horizontal input: " + horizontal);
		   if (!isAbleToMove && horizontal > 0f)
			{
				horizontal = 0f;
			}
		}
		else
		{
			horizontal = 0f; // If player is unable to move don't move the player
		}
	}
}