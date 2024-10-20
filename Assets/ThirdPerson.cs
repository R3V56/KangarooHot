using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPerson : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("References")]
    public Transform orientation;
    public Transform player;
    public Transform playerobj;
    public Rigidbody rb;

    public float rotationSpeed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //rotate orientation
        Vector3 viewDir = player.position - new Vector3(transform.position.x, player.position.y, transform.position.z);
        orientation.forward = viewDir.normalized;

        // rotate player object
        float horizontalInut = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 inputDir = orientation.forward * verticalInput + orientation.right * horizontalInut;


        if (inputDir != Vector3.zero)
            playerobj.forward = Vector3.Slerp(playerobj.forward, inputDir.normalized, Time.deltaTime * rotationSpeed);
    }

}
