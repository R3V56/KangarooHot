using System.Collections;
using UnityEngine;

public class MouseClickCooldown : MonoBehaviour
{
    public float clickCooldownDuration = 4f; // Cooldown duration in seconds
    private bool canClick = true; // Flag to control click cooldown

    public static MouseClickCooldown Instance; // Singleton instance for global access

    void Awake()
    {
        // Create a singleton instance
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public bool IsClickAllowed()
    {
        return canClick;
    }

    public void TriggerCooldown()
    {
        if (canClick)
        {
            StartCoroutine(HandleClickCooldown());
        }
    }

    private IEnumerator HandleClickCooldown()
    {
        canClick = false; // Disable clicks
        yield return new WaitForSeconds(clickCooldownDuration); // Wait for cooldown duration
        canClick = true; // Re-enable clicks
    }
}
