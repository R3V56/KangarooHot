using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{

    public float boomTime = 6f;
    public GameObject BombKey;
    // Start is called before the first frame update
    void Start()
    {
        BombKey = GameObject.FindWithTag("BombKey");

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

}
