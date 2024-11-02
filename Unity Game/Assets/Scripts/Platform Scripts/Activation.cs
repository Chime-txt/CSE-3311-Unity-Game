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
    private float timeSinceActivation;

    // Start is called before the first frame update
    void Start()
    {
		timeSinceActivation = 0.0f;
	}

	// Assigns an object that needs to be destroyed
	[SerializeField] GameObject TargetObject;

    // Update is called once per frame
    void FixedUpdate()
    {
        // If the TargetObject is destroyed
        if (TargetObject == null)
        {
			// Get the time difference since the TargetObject has been destroyed
			// and add it to the time since activation
            // This fix resolves the issue of the osalating object teleporting after
            // the target object has been destroyed
			timeSinceActivation = timeSinceActivation + Time.deltaTime;

			// Calculate the new position using Mathf.Sin
			float oscillation = Mathf.Sin(timeSinceActivation * frequency) * amplitude;

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
        else
        {
            // Sets the time since the TargetObject was destroyed back to 0
            // since the Target Object has not been destroyed
			timeSinceActivation = 0.0f * Time.deltaTime;
        }
    }
}
