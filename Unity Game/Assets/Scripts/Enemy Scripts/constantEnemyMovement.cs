using UnityEngine;

public class constantEnemyMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] float moveSpeed = 2.0f;
    [SerializeField] bool isXAxis = true;

    [Header("DO NOT ALTER VALUE")]
    public bool isMoving = true;

    [SerializeField] Animator animator;
    private SpriteRenderer spriteRenderer;
    private bool isFacingRight = true;

    private bool flipLock;

    void Start()
    {
        flipLock = false;
		spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update the movement at a fixed rate
    void FixedUpdate()
    {
        if (!flipLock && isMoving)
        {
            // Move the enemy at a constant rate
            Vector3 movement = isXAxis ? Vector3.right : Vector3.up;
            transform.Translate(movement * moveSpeed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Blue") || other.gameObject.CompareTag("Red"))
        {
            isMoving = false;

            // Flip the enemy sprite based on the position of the other object
            if (other.gameObject.transform.position.x < transform.position.x && isFacingRight)
            {
                FlipEnemy();
            }
            else if (other.gameObject.transform.position.x > transform.position.x && !isFacingRight)
            {
                FlipEnemy();
            }

            animator.SetBool("Attack", !isMoving);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!flipLock && other.gameObject.CompareTag("Wall"))
        {
            flipLock = true;
			FlipEnemy();
        }
    }

    /// <summary>
    /// Flips the enemy's facing direction.
    /// </summary>
    private void FlipEnemy()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        moveSpeed = -moveSpeed;
        transform.localScale = localScale;
        flipLock = false;
	}
}
