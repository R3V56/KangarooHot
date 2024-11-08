using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartEnd : MonoBehaviour

{
    public Vector3 airrate = new Vector3(.05f, .05f, .05f);

    void FixedUpdate()
    {
        Ray laser = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(laser, out hit) && Input.GetMouseButtonDown(0))
        {
            if (hit.collider.CompareTag("GoToGame"))
            {
		     SceneManager.LoadScene("KangarooHotel");
            }

            if (hit.collider.CompareTag("GoToStart"))
            {
                Debug.Log("WompWomp");
		     SceneManager.LoadScene("Start");
            }
            
        }
    }
}


