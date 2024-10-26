using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float explosionRadius = 5.0f;   // Radius within which customers will be affected
    public LayerMask customerLayer;        // Layer for customers
    public float delayBeforeExplosion = 2.0f; // Optional delay before the bomb explodes

    void Start()
    {
        // Start the explosion after the delay
        Invoke(nameof(Explode), delayBeforeExplosion);
    }

    private void Explode()
    {
        // Visualize explosion radius for debugging (optional)
        Debug.DrawLine(transform.position, transform.position + Vector3.up * explosionRadius, Color.red, 2f);

        // Find all colliders within the explosion radius
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, explosionRadius, customerLayer);

        // Loop through each collider and destroy the customer object
        foreach (Collider hitCollider in hitColliders)
        {
            // Check if the collider belongs to a customer
            if (hitCollider.CompareTag("Customer"))
            {
                Destroy(hitCollider.gameObject); // Eliminate customer
            }
        }

        // Optionally play explosion effect or sound (assuming you have an explosion effect attached)
        // Destroy or deactivate the bomb itself after explosion
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        // Draw the explosion radius in the editor view for easy setup
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}