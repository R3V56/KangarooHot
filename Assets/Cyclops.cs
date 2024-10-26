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





    void FixedUpdate()
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
                StartCoroutine(HandleHitWithDelay());
                Debug.Log("key item clicked");
                //spawn rigidbody that deletes matching customers
            }

            if (hit.collider.CompareTag("luggage"))
            {
                Debug.Log("luggage");
                StartCoroutine(HandleHitWithDelay());
                Debug.Log("luggage item clicked");
                //spawn rigidbody that deletes matching customers
            }
            if (hit.collider.CompareTag("reservation"))
            {
                Debug.Log("reservation");
                StartCoroutine(HandleHitWithDelay());
                Debug.Log("reservation item clicked");
                //spawn rigidbody that deletes matching customers
            }
            if (hit.collider.CompareTag("CustomerReservation"))
            {
                Debug.Log("CustomerReservation");
                StartCoroutine(HandleHitWithDelay());
                Debug.Log("Customer clicked");
                //spawn rigidbody that deletes matching customers
            }

            if (hit.collider.CompareTag("CustomerKey"))
            {
                Debug.Log("CustomerKey");
                StartCoroutine(HandleHitWithDelay());
                Debug.Log("Customer clicked");
                //spawn rigidbody that deletes matching customers
            }

            if (hit.collider.CompareTag("CustomerLuggage"))
            {
                Debug.Log("CustomerLuggage");
                StartCoroutine(HandleHitWithDelay());
                Debug.Log("Customer clicked");
                //spawn rigidbody that deletes matching customers
            }







        }





        if (Physics.Raycast(laser, out hit) && Input.GetMouseButton(1))
        {
            //same thing for the right mouse button, but instead of adding force, we spawn a new prefab
            hit.transform.localScale += airrate;
         
         // Instantiate(prefab, hit.point, Quaternion.identity);
            if (hit.transform.localScale.y > 10f)
            {
                Destroy(hit.transform.gameObject);
            }
        }
    }

    private IEnumerator HandleHitWithDelay()
    {
         //Perform any immediate action here
        Debug.Log("Processing hit...");

        // Wait for the specified duration
        yield return new WaitForSeconds(KeyDelayDuration);

        // Perform the action after the delay
        Debug.Log("Action completed after delay!");
    }
}
//if customer deleted send signal to specific line
//move back 2 customers forward
//rand 1-3 at pos 3 of line (1=key 2=luggage 3=reservation)
//
