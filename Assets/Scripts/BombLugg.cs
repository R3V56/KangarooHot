using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombLugg : MonoBehaviour
{
    public float boom = 1f;
    public GameObject BombLuggage;
    public GameObject BombReservation;
    public GameObject BombKey;
    public GameObject Confetti;
    // Start is called before the first frame update
    void Start()
    {
        BombLuggage = GameObject.FindWithTag("BombLuggage");
        BombKey = GameObject.FindWithTag("BombReservation");
        BombKey = GameObject.FindWithTag("BombLuggage");
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

            SpawnConfetti(other.transform.position); // Spawn confetti at the object's position
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
