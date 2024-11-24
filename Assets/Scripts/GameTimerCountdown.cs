using System.Collections.Generic;
using UnityEngine;

public class GameTimerCountdown : MonoBehaviour
{
    public float timeRemaining = 60f;


    void Update()
    {
        if (timeRemaining > 0f)
        {
            timeRemaining -= Time.deltaTime;

            Debug.Log(timeRemaining + "Time has run out!");

            //Game Over
        }
        else
        {
            Manager.timeRemaining -= 1;
            Debug.Log("Time has run out!");

            //Destroy 1/2 star prefab


        }

    }

}