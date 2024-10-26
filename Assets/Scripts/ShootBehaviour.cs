using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBehaviour : MonoBehaviour
{
    public float speed = 10f;
    public GameObject BulletHit;
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
        rb.velocity = transform.forward * speed;
    }

    void OnTriggerEnter(Collider other)
    {
    //    if (other.CompareTag("CustomerLuggage")){

        //  other.gameObject.GetComponent < EnemyHealth > ().Health --;
        // if (other.gameObject.GetComponent < EnemyHealth > ().Health < 1){
        //   Destroy(other.gameObject);
        //   Manager.score += 1;
        // }
    //    }
        // Destroy the bullet if it hits an enemy or goes out of bounds
        if (other.CompareTag("CustomerLuggage") || other.CompareTag("Bounds"))
        {
            Instantiate(BulletHit, transform.position, transform.rotation);
            Destroy(gameObject);



        }
    }
    void Update()
    {
        // transform.localEulerAngles = new Vector3 (0, (Input.mousePosition.x / Screen.width)*720f, 0);


    }
}
