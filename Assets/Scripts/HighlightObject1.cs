using UnityEngine;

public class HighlightObject : MonoBehaviour
{
    private Material originalMaterial; // Store the original material
    public Material highlightMaterial; // Material to use for highlighting

    private Renderer objectRenderer;

    void Start()
    {
        objectRenderer = GetComponent<Renderer>();
        if (objectRenderer != null)
        {
            originalMaterial = objectRenderer.material; // Cache the original material
        }
    }

    void OnMouseDown()
    {
        Highlight(); // Highlight when the object is clicked
    }

    void OnMouseUp()
    {
        RemoveHighlight(); // Remove highlight when the mouse button is released
    }

    public void Highlight()
    {
        if (objectRenderer != null && highlightMaterial != null)
        {
            objectRenderer.material = highlightMaterial; // Apply highlight material
            Debug.Log($"{gameObject.name} is highlighted!"); // Log for debugging
        }
    }

    public void RemoveHighlight()
    {
        if (objectRenderer != null && originalMaterial != null)
        {
            objectRenderer.material = originalMaterial; // Restore original material
            Debug.Log($"{gameObject.name} highlight removed."); // Log for debugging
        }
    }
}