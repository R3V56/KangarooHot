using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseControlledRotation : MonoBehaviour
{
    public float rotationSpeed = 100f; // Speed at which the object rotates

    private void Update()
    {
        // Get horizontal mouse movement
        float mouseX = Input.GetAxis("Mouse X");

        // Rotate the object around the Y-axis for horizontal rotation
        transform.Rotate(0f, mouseX * rotationSpeed * Time.deltaTime, 0f, Space.World);
    }
}