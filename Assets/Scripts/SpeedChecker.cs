using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedChecker : MonoBehaviour
{
    public Rigidbody rb; // Assign the Rigidbody in the inspector
    public float speedThreshold = 1.0f; // Set your speed threshold
    public float timeThreshold = 2.0f; // Set the time duration to check
    private float timeBelowThreshold = 0f; // Timer for how long speed is below threshold

    void Update()
    {
        // Check the current speed of the rigidbody
        float currentSpeed = rb.velocity.magnitude;

        // Check if the speed is below the threshold
        if (currentSpeed < speedThreshold)
        {
            // Increment the timer
            timeBelowThreshold += Time.deltaTime;

            // Check if the time below threshold has been met
            if (timeBelowThreshold >= timeThreshold)
            {
                OnSpeedBelowThreshold(); // Call your desired method
            }
        }
        else
        {
            // Reset the timer if speed is above the threshold
            timeBelowThreshold = 0f;
        }
    }

    void OnSpeedBelowThreshold()
    {
        Debug.Log("Speed has been below the threshold for the set duration!");
        // Implement any logic you want to trigger here
    }
}
