using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMove : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 10f;
    void Start()
    {
      Rigidbody rb = GetComponent<Rigidbody>();
      rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
      rb.velocity = transform.forward * speed;
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider other)
    {
       if (other.CompareTag("Earth")){
         SceneManager.LoadScene("Final");}

  }
}
