using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpeedChecker : MonoBehaviour
{
    public Rigidbody rb; // Assign the Rigidbody in the inspector
    public float speedThreshold = 1.0f; // Set your speed threshold
    public float timeThreshold = 2.0f; // Set the time duration to check
    private float timeBelowThreshold = 0f; // Timer for how long speed is below threshold
    public float ReviewDelay = 2f;
    public GameObject StarL;
    

    public AudioClip StarDeath;
    private AudioSource audioSource; // AudioSource component

    void Start()
    {
        // Add an AudioSource component to the GameObject this script is attached to
        audioSource = gameObject.AddComponent<AudioSource>();
    }
    void Update()
    {
        // Check the current speed of the rigidbody
        float currentSpeed = rb.velocity.magnitude;


        StarL = GameObject.FindWithTag("StarL");
        transform.GetChild(0).GetChild(1).gameObject.GetComponent<Renderer>().material.color = Color.Lerp(Color.white, Color.red, timeBelowThreshold / timeThreshold);

        // Check if the speed is below the threshold

        if (currentSpeed < speedThreshold)
        {
            // Increment the timer
            timeBelowThreshold += Time.deltaTime;

            // Check if the time below threshold has been met
            if (timeBelowThreshold >= timeThreshold)
            {
                OnSpeedBelowThreshold(); // Call your desired method
		        timeThreshold += timeBelowThreshold;
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
        Debug.Log("I want to see the manager!");

        StartCoroutine(UpdateStarRating());
      


        // Implement any logic you want to trigger here
    }
    private IEnumerator UpdateStarRating()
    {
        //Perform any immediate action here

        Debug.Log("I'm going to leave a horrible review");

        Manager.star -= 1;
        PlaySound(StarDeath);
        Destroy(StarL.transform.GetChild(Manager.star).gameObject);
        //Destroy(StarR);
       



        // Wait for the specified duration

        yield return new WaitForSeconds(ReviewDelay);
        //Destroy(StarL);
        //Destroy(StarR);
        // Perform the action after the delay


        Debug.Log("Star rating updated");
    }
    void PlaySound(AudioClip clip)
    {
        if (clip != null && audioSource != null)
        {
            audioSource.PlayOneShot(clip); // Play the assigned sound
        }
    }
}
