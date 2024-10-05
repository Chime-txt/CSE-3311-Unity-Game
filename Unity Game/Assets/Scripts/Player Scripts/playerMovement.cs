using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public bool isOnGround = true;
    public bool isAbleToMove = true;

    private float horizontal;
    [SerializeField] float speed = 8f;
    [SerializeField] float jumpingPower = 16f;
    private bool isFacingRight = true;

    public Animator animator;

    void Update()
    {
        FlipMethod();
        IsGrounded(); // Continuously check if on ground
    }

    private void FlipMethod()
    {
        if (!isFacingRight && horizontal > 0f) //if moving right
        {
            Flip();
        }
        else if (isFacingRight && horizontal < 0f) //if moving left
        {
            Flip();
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y); //ensures smooth physics
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (isAbleToMove)
        { 
            if (context.performed && isOnGround) // Use isOnGround directly
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpingPower); // jump
                isOnGround = false;
                animator.SetBool("isJumping", !isOnGround);
            }

            if (context.canceled && rb.velocity.y > 0f)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f); //go down
                animator.SetBool("isJumping", false);
            }
        }
}

    private bool IsGrounded()
    {
        bool grounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        if (grounded)
        {
            isOnGround = true;
            animator.SetBool("isJumping", !isOnGround);
        }
        else
        {
            isOnGround = false; // Update isOnGround if not grounded
            animator.SetBool("isJumping", !isOnGround);
        }
        return grounded;
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f; // flip
        transform.localScale = localScale;
    }

    public void Move(InputAction.CallbackContext context)
    {
        if (isAbleToMove)
        {
            horizontal = context.ReadValue<Vector2>().x;// move on the x axis (not needed for y-axis because it's a 2D game
           //Debug.Log("Horizontal input: " + horizontal);
           if (!isAbleToMove && horizontal > 0f)
            {
                horizontal = 0f;
            }
        }
        else
        {
            horizontal = 0f;
        }
    }

}