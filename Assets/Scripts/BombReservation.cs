using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombReservation : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BombReservation"))
        {
            Destroy(other.gameObject);

        }

    }
}
