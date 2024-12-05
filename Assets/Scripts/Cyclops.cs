using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cyclops : MonoBehaviour
{ 
    //float time = 0f;
    //float timeDelay = 3f;

    public float explosionForce = 1f;
    public float explosionRadius = 100f;
    public GameObject prefab;
    public float score = 0f;
    public Vector3 airrate = new Vector3(.05f, .05f, .05f);
    public float KeyDelayDuration = 2f;
    public float LugDelayDuration = 3f;
    public float ResDelayDuration = 4f;
    public Transform BombSpawn;
    public GameObject bomb_key, bomb_luggage, bomb_reservation, bomb;

    public AudioClip keyClickSound; // Sound for key object
    public AudioClip luggageClickSound; // Sound for luggage object
    public AudioClip reservationClickSound; // Sound for reservation object

    private AudioSource audioSource; // AudioSource component

    

    void Start()
    {
        // Add an AudioSource component to the GameObject this script is attached to
        audioSource = gameObject.AddComponent<AudioSource>();
    }
    void Update()
    {
        

        
        
        //create a new Ray object called laser
        //and use the ScreenPointToRay method of cameras
        //which takes an argument of a vector3 corresponding to screen position
        //we used mousePosition from the input class
        // public float delayDuration = 2f;
        Ray laser = Camera.main.ScreenPointToRay(Input.mousePosition);

        //raycasthit is a class that will store information for a raycast hitting something
        //we use the constructor (new RaycastHit()) to initialize it
        RaycastHit hit = new RaycastHit();

        //Physics.Raycast will cast our ray and return true if it hits a collider
        //if thats true and the left mouse button is pressed, then do the following
        if (Physics.Raycast(laser, out hit) && Input.GetMouseButtonDown(0))
        {
            //Debug.Log("booyah cyclops sucks?");
            //if (hit.rigidbody){ //if the thing we hit has a rigidbody
            //add explosion force to the rigidbody we hit using the variables we created at the point we hit it
            hit.rigidbody.AddExplosionForce(explosionForce, hit.point, explosionRadius);

            if (hit.collider.CompareTag("key"))
            {
                Debug.Log("key");
                PlaySound(keyClickSound);
                StartCoroutine(HandleHitWithDelay(KeyDelayDuration, bomb_key));
                //  Debug.Log("key item clicked");
                // bomb = bomb_key;

                //Instantiate(bomb, BombSpawn.position, BombSpawn.rotation);
            }

            if (hit.collider.CompareTag("luggage"))
            {
                Debug.Log("luggage");
                PlaySound(luggageClickSound);
                StartCoroutine(HandleHitWithDelay(LugDelayDuration, bomb_luggage));
                //Debug.Log("luggage item clicked");
                // bomb = bomb_luggage;

                //Instantiate(bomb, BombSpawn.position, BombSpawn.rotation);
            }
            if (hit.collider.CompareTag("reservation"))
            {
                Debug.Log("reservation");
                PlaySound(reservationClickSound);
                StartCoroutine(HandleHitWithDelay(ResDelayDuration, bomb_reservation));
                // Debug.Log("reservation item clicked");
                // bomb = bomb_reservation;

                //Instantiate(bomb, BombSpawn.position, BombSpawn.rotation);
            }








        }
    }
             void PlaySound(AudioClip clip)
             {
                     if (clip != null && audioSource != null)
                     {
                       audioSource.PlayOneShot(clip); // Play the assigned sound
                     }
             }


            
        

    IEnumerator HandleHitWithDelay(float MyItemDelay, GameObject CurrentBomb)
    {
        //Perform any immediate action here
        Debug.Log("Processing hit...");

        // Wait for the specified duration
        yield return new WaitForSeconds(MyItemDelay);

        // Perform the action after the delay
        Debug.Log("Action completed after delay!");

        Debug.Log("key item clicked");
        bomb = CurrentBomb;

        Instantiate(bomb, BombSpawn.position, BombSpawn.rotation);

    }

}
//if customer deleted send signal to specific line
//move back 2 customers forward
//rand 1-3 at pos 3 of line (1=key 2=luggage 3=reservation)
//



