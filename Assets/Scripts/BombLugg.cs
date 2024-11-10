using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombLugg : MonoBehaviour
{
    public float boom = 1f;
    public GameObject BombLuggage;
    // Start is called before the first frame update
    void Start()
    {
        BombLuggage = GameObject.FindWithTag("BombLuggage");

        //yield return new WaitForSeconds(boomTime);
        if (boom == 0f)
        {
            //  StartCoroutine(HandleHitWithDelay());
	    Manager.score += 1;
            Destroy(BombLuggage);
        }

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CustomerLuggage"))
        {
            Destroy(other.gameObject);
            Debug.Log("KAboooom");
	       Manager.score += 1;
        }

    }
    void DestroyObjectDelayed()
    {
        // Kills the game object in 5 seconds after loading the object
        Destroy(BombLuggage, 5);
    }
    private IEnumerator HandleHitWithDelay()
    {
        //Perform any immediate action here
        Debug.Log("Bomb Ignited...");

        // Wait for the specified duration
        yield return new WaitForSeconds(boom);

        // Perform the action after the delay
        Debug.Log("Boom");
    }
}
