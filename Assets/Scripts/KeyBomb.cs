using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb_KeySript : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BombKey"))
        {
            Destroy(other.gameObject);
            Debug.Log("KAboooom");
	    Manager.score += 1;
        }
    
    }
}
