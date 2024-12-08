using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{

    public float boomTime = 6f;
    public GameObject BombKey;
    public GameObject BombLuggage;
    public GameObject BombReservation;
    public GameObject Confetti;

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
            SpawnConfetti(other.transform.position); // Spawn confetti at the object's position
            Destroy(other.gameObject);
 
            Debug.Log("KAboooom");
        }

        

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

        if (obj != null)
        {
            SpawnConfetti(obj.transform.position); // Spawn confetti at the object's position
            Destroy(obj);
            Debug.Log($"{obj.name} has been destroyed.");
        }
    }
    private void SpawnConfetti(Vector3 position)
    {
        if (Confetti != null)
        {
            Instantiate(Confetti, position, Quaternion.identity); // Spawn confetti effect
        }
        else
        {
            Debug.LogWarning("Confetti prefab is not assigned!");
        }
    }

}
