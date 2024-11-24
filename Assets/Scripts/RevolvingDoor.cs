using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RevolvingDoor : MonoBehaviour
{

    public Vector3 RevolvingDoorObject;
    // Start is called before the first frame update

    void Update()
    {
        {
            transform.Rotate(RevolvingDoorObject);
        }
    }

    // Update is called once per frame





}