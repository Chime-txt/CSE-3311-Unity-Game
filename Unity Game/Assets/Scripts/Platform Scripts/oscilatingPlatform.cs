using UnityEngine;

public class OscillatingPlatform : MonoBehaviour
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


    void Start()
    {
        // Store the initial position of the platform
        startPosition = transform.position;
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
    //private void OnCollisionEnter2D(Collision2D other)
    //{
    //    if (other.gameObject.CompareTag("Blue") || other.gameObject.CompareTag("Red"))
    //    {
    //        isMoving = false;
    //    }
    //}
}
