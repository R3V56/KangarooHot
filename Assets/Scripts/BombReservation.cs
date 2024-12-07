using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombReservation : MonoBehaviour
{
    //public GameObject ConfettiPrefab;

   

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BombReservation"))
        {
            Destroy(other.gameObject);
            //Instantiate(ConfettiPrefab, other.transform.position, Quaternion.identity);
            Debug.Log("Boom condition met!");


        }

    }
}
