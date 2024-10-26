using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerSript : MonoBehaviour
{
    int angle = 0;

    public Transform EnemySpawn;

    float time = 0f;
    float timeDelay = 3f;
    
    public GameObject customer_key, customer_luggage, customer_reservation, customers;
    // Start is called before the first frame update
    
    void Start()
    {
        time = 0f;
        timeDelay = 2f;
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
    
      
        
    }
    // Update is called once per frame
    void Update()
    {
        int buns = Random.Range(1, 4);
        if (buns == 1)
        {
            customers = customer_key;
        }
        if (buns == 2)
        {
            customers = customer_reservation;
        }
        if (buns == 3)
        {
            customers = customer_luggage;
        }
        if (buns == 4)
        {
            customers = customer_luggage;
        }
        time = time + 1f * Time.deltaTime;

          if (time >= timeDelay)
          {
            time = 0f;
            int yum = Random.Range(1, 4);
            if (yum == 1)
            {
                angle = 0;
            }
            if (yum == 2)
            {
                angle = 90;
            }
            if (yum == 3)
            {
                angle = 180;
            }
            if (yum == 4)
            {
                angle = 270;
            }
            transform.localEulerAngles = new Vector3(0, angle, 0);
            Instantiate(customers, EnemySpawn.position, EnemySpawn.rotation);

          }
        


    }
}
