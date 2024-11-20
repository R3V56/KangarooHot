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

    public void Highlight()
    {
        if (objectRenderer != null && highlightMaterial != null)
        {
            objectRenderer.material = highlightMaterial; // Apply highlight material
        }
    }

    public void RemoveHighlight()
    {
        if (objectRenderer != null && originalMaterial != null)
        {
            objectRenderer.material = originalMaterial; // Restore original material
        }
    }
}

