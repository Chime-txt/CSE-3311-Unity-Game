using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask groundLayer;

    private float horizontal;
    [SerializeField] float speed = 8f;
    [SerializeField] float jumpingPower = 16f;
    private bool isFacingRight = true;

    void Update()
    {
        FlipMethod();
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
        if (context.performed && IsGrounded()) //If button is pressed and on the ground
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower); //jump
        }

        if (context.canceled && rb.velocity.y > 0f) // if button is pressed and moving upward
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f); //go down
        }
    }

    private bool IsGrounded() 
    {
        //if touching the ground set to true
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
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
        horizontal = context.ReadValue<Vector2>().x;// move on the x axis (not needed for y-axis because it's a 2D game
        Debug.Log("Horizontal input: " + horizontal);
    }

}