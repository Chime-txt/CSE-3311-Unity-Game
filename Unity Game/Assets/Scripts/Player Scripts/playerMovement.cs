using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{
	[Header("Player")]
	[SerializeField] Rigidbody2D rigidBody2D;
	[SerializeField] Transform groundCheck;
	[SerializeField] LayerMask groundLayer;
	[SerializeField] Animator animator;

	[Header("Movement")]
	[SerializeField] float speed = 8f;
	[SerializeField] float jumpingPower = 16f;
#pragma warning disable CA1051 // Do not declare visible instance fields
	public bool isOnGround = true;
	public bool isAbleToMove = true;
#pragma warning restore CA1051 // Do not declare visible instance fields
	private float horizontal;
	private bool isFacingRight = true;

    // Get the music
    [SerializeField] AudioClip audioclip;
    [SerializeField] AudioSource audioSource;

	// Start is called before the first frame update
	void Start()
	{
		audioSource = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>();
	}

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
			rigidBody2D.velocity = new Vector2(horizontal * speed, rigidBody2D.velocity.y); // Ensures smooth physics
		}
	}

	public void Jump(InputAction.CallbackContext context)
	{
		if (isAbleToMove)
		{ 
			if (context.performed && isOnGround) // Use isOnGround directly
			{
				audioSource.PlayOneShot(audioclip);
				rigidBody2D.velocity = new Vector2(rigidBody2D.velocity.x, jumpingPower); // Jump
				isOnGround = false;
				animator.SetBool("isJumping", !isOnGround);
			}

			if (context.canceled && rigidBody2D.velocity.y > 0f) // If the player is falling down
			{
				rigidBody2D.velocity = new Vector2(rigidBody2D.velocity.x, rigidBody2D.velocity.y * 0.5f); // Go down
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