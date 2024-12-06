using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{

    public float boomTime = 6f;
    public GameObject BombKey;
    public GameObject BombLuggage;
    public GameObject BombReservation;
    // Start is called before the first frame update
    void Start()
    {
        BombKey = GameObject.FindWithTag("BombKey");
        BombKey = GameObject.FindWithTag("BombLuggage");
        BombKey = GameObject.FindWithTag("BombReservation");
        //yield return new WaitForSeconds(boomTime);
        if (boomTime == 0f)
        {
          //  StartCoroutine(HandleHitWithDelay());
            Destroy(BombKey);

        }
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CustomerKey"))
        {
            Destroy(other.gameObject);
            Debug.Log("KAboooom");
        }

        

    }
    void DestroyObjectDelayed()
    {
        // Kills the game object in 5 seconds after loading the object
        Destroy(BombKey, 5);
    }
    private IEnumerator HandleHitWithDelay()
    {
         //Perform any immediate action here
         Debug.Log("Bomb Ignited...");

         // Wait for the specified duration
         yield return new WaitForSeconds(boomTime);

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
