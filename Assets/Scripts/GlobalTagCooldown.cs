using System.Collections;
using UnityEngine;

public class GlobalTagCooldown : MonoBehaviour
{
    public float cooldownDuration = 1f; // Duration to block clicks globally
    private static bool isCooldownActive = false; // Shared state to block clicks globally

    private static string lastClickedTag = ""; // Store the last clicked tag (optional, for debugging)

    private Renderer objectRenderer; // Reference to the object's renderer
    private int originalLayer; // Store the original layer

    void Start()
    {
        objectRenderer = GetComponent<Renderer>();
        originalLayer = gameObject.layer; // Cache the object's layer
    }

    private void OnMouseDown()
    {
        if (isCooldownActive)
        {
            Debug.Log($"Click blocked! Global cooldown is active. Last clicked tag: {lastClickedTag}");
            return;
        }

        // Start the cooldown and process the click
        lastClickedTag = gameObject.tag; // Track the last clicked tag
        Debug.Log($"{gameObject.name} with tag '{lastClickedTag}' clicked!");

        StartCoroutine(StartGlobalCooldown());
    }

    private IEnumerator StartGlobalCooldown()
    {
        isCooldownActive = true; // Activate cooldown globally
        DisableInteraction(); // Disable interaction with this object
        yield return new WaitForSeconds(cooldownDuration); // Wait for cooldown duration
        EnableInteraction(); // Re-enable interaction with this object
        isCooldownActive = false; // Deactivate cooldown globally
        lastClickedTag = ""; // Clear the last clicked tag (optional)
        Debug.Log("Global cooldown ended.");
    }

    private void DisableInteraction()
    {
        // Temporarily set the object's layer to Ignore Raycast
        gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
        Debug.Log($"{gameObject.name} interaction disabled.");
    }

    private void EnableInteraction()
    {
        // Restore the object's original layer
        gameObject.layer = originalLayer;
        Debug.Log($"{gameObject.name} interaction enabled.");
    }
}
