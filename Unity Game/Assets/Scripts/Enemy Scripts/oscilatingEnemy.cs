using UnityEngine;

public class OscillatingEnemy : MonoBehaviour
{
    // Start position
    private Vector3 startPosition;

    [Header("DO NOT ALTER VALUE")]
    public bool isMoving = true;

    [Header("Amplitude: How far the platform moves from the start position")]
    [SerializeField] float amplitude = 5.0f;
    [SerializeField] bool isXAxis = true;

    [Header("Frequency: Speed of the oscillation")]
    [SerializeField] float frequency = 1.0f;

    [SerializeField] Animator animator;
    private SpriteRenderer spriteRenderer;


    void Start()
    {
        // Store the initial position of the platform
        startPosition = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (isMoving)
        {
            // Calculate the new position using Mathf.Sin
            float oscillation = Mathf.Sin(Time.time * frequency) * amplitude;

            // Apply the oscillation to the platform's position 
            if (isXAxis)
            {
                transform.position = new Vector2(startPosition.x + oscillation, startPosition.y);
            }
            else
            {
                transform.position = new Vector2(startPosition.x, startPosition.y + oscillation);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Blue") || other.gameObject.CompareTag("Red"))
        {
            isMoving = false;
            // Flip the enemy sprite based on the position of the other object
            if (other.gameObject.transform.position.x < transform.position.x)
            {
                // Object is to the left, flip to face left
                spriteRenderer.flipX = true;
            }
            animator.SetBool("Attack", !isMoving);
        }
    }
}
