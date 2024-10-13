using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activation : MonoBehaviour
{
    // Start position
    private Vector3 startPosition;

    // Amplitude: How far the platform moves from the start position
    [SerializeField] float amplitude = 5.0f;
    [SerializeField] bool isXAxis = true;

    // Frequency: Speed of the oscillation
    [SerializeField] float frequency = 1.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Assigns an object that needs to be destroyed
    public GameObject TargetObject;

    // Update is called once per frame
    void Update()
    {
        // If the TargetObject is destroyed
        if (TargetObject == null)
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
}
