using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReservationBomb : MonoBehaviour
{
    public float kaboom = 1f;
    public GameObject BombReservation;
    // Start is called before the first frame update
    void Start()
    {
        BombReservation = GameObject.FindWithTag("BombReservation");

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
}
