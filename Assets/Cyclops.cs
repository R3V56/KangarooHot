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
    //public float delayDuration = 2f;







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
        if (Physics.Raycast(laser, out hit) && Input.GetMouseButton(0))
        {
            //Debug.Log("booyah cyclops sucks?");
            //if (hit.rigidbody){ //if the thing we hit has a rigidbody
            //add explosion force to the rigidbody we hit using the variables we created at the point we hit it
            hit.rigidbody.AddExplosionForce(explosionForce, hit.point, explosionRadius);
        }




            if (hit.collider.CompareTag("key"))
            {
                Debug.Log("key");
               //2 delay
               Debug.Log("key done");
               //spawn rigidbody that deletes matching customers
            }

            if (hit.collider.CompareTag("luggage"))
            {
                Debug.Log("luggage");
               //3 delay
               Debug.Log("luggage done");
               //spawn rigidbody that deletes matching customers
               //
            }
            if (hit.collider.CompareTag("reservation"))
            {
                Debug.Log("reservation");
                //4 delay
                Debug.Log("reservation done");
                //spawn rigidbody that deletes matching customers
            }

            if (Physics.Raycast(laser, out hit) && Input.GetMouseButton(1))
            {
                //same thing for the right mouse button, but instead of adding force, we spawn a new prefab
                hit.transform.localScale += airrate;
                //Instantiate(prefab, hit.point, Quaternion.identity);
                if (hit.transform.localScale.y > 10f)
                {
                    Destroy(hit.transform.gameObject);
                }
            }

    }
}
//if customer deleted send signal to specific line
  //move back 2 customers forward
  //rand 1-3 at pos 3 of line (1=key 2=luggage 3=reservation)
  //
