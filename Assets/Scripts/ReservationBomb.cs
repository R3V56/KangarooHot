using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReservationBomb : MonoBehaviour
{
    public float kaboom = 1f;
    public GameObject BombReservation;
    public GameObject BombLuggage;
    public GameObject BombKey;
    // Start is called before the first frame update
    void Start()
    {
        BombReservation = GameObject.FindWithTag("BombReservation");
        BombKey = GameObject.FindWithTag("BombKey");
        BombKey = GameObject.FindWithTag("BombLuggage");
        //yield return new WaitForSeconds(boomTime);
        if (kaboom == 0f)
        {
            //  StartCoroutine(HandleHitWithDelay());
            Destroy(BombReservation);
        }

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CustomerReservation"))
        {
            Destroy(other.gameObject);
            Debug.Log("KAboooom");
	     Manager.score += 1;
        }
        if (other.CompareTag("BombKey"))
        {
            StartCoroutine(DelayDestruction(other.gameObject, 2f)); // Delay destruction by 2 seconds
          //  Destroy(other.gameObject);
            Debug.Log("KAboooom");
        }

        if (other.CompareTag("BombLuggage"))
        {
            StartCoroutine(DelayDestruction(other.gameObject, 2f)); // Delay destruction by 2 seconds
           // Destroy(other.gameObject);
            Debug.Log("KAboooom");
        }

    }
    void DestroyObjectDelayed()
    {
        // Kills the game object in 5 seconds after loading the object
        Destroy(BombReservation, 5);
    }
    private IEnumerator HandleHitWithDelay()
    {
        //Perform any immediate action here
        Debug.Log("Bomb Ignited...");

        // Wait for the specified duration
        yield return new WaitForSeconds(kaboom);

        // Perform the action after the delay
        Debug.Log("Boom");
    }
    private IEnumerator DelayDestruction(GameObject obj, float delay)
    {
        Debug.Log($"Delaying destruction of {obj.name} for {delay} seconds.");
        yield return new WaitForSeconds(delay);
        if (obj != null) // Ensure the object hasn't been destroyed already
        {
            Destroy(obj);
            Debug.Log($"{obj.name} has been destroyed.");
        }
    }
}
