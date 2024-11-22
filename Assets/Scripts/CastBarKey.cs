using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CastBar : MonoBehaviour
{
    public float explosionForce = 1f;
    public float explosionRadius = 100f;
    public float KeyDelayDuration = 1f;
    

    public Transform BombSpawn; // Location where bombs will spawn
    public GameObject bomb_key; // Bomb prefabs
    public Slider progressBar; // UI Progress Bar

    private GameObject bomb; // Current bomb being used

    void Update()
    {
        // Create a Ray from the mouse position
        Ray laser = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // Detect left mouse click and raycast hit
        if (Physics.Raycast(laser, out hit) && Input.GetMouseButtonDown(0))
        {
            // Apply explosion force if the hit object has a Rigidbody
            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddExplosionForce(explosionForce, hit.point, explosionRadius);
            }

            // Check the tag of the object hit and handle accordingly
            if (hit.collider.CompareTag("key"))
            {
                StartCoroutine(HandleHitWithDelay(KeyDelayDuration, bomb_key));
            }
            
        }
    }

    IEnumerator HandleHitWithDelay(float delayDuration, GameObject selectedBomb)
    {
        bomb = selectedBomb; // Assign the current bomb
        progressBar.gameObject.SetActive(true); // Show the progress bar
        progressBar.value = 0f; // Reset progress bar

        float elapsedTime = 0f;

        // Update the progress bar during the delay
        while (elapsedTime < delayDuration)
        {
            elapsedTime += Time.deltaTime;
            progressBar.value = Mathf.Clamp01(elapsedTime / delayDuration);
            yield return null;
        }

        // Complete the action
        Instantiate(bomb, BombSpawn.position, BombSpawn.rotation);
        progressBar.gameObject.SetActive(false); // Hide the progress bar
    }
}



