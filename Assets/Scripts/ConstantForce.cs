using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantForceTrigger : MonoBehaviour
{
    public Vector3 constantForce = new Vector3(0, 0, 100); // Adjust this to your desired force

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object has a Rigidbody
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (rb != null)
        {
            // Start applying constant force
            StartCoroutine(ApplyConstantForce(rb));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Stop applying force when the object exits the trigger
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (rb != null)
        {
            StopCoroutine(ApplyConstantForce(rb));
        }
    }

    private IEnumerator ApplyConstantForce(Rigidbody rb)
    {
        while (true)
        {
            rb.AddForce(constantForce, ForceMode.Force);
            yield return null; // Wait for the next frame
        }
    }
}

