using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombLuggage : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BombLuggage"))
        {
            Destroy(other.gameObject);

        }

    }
}
