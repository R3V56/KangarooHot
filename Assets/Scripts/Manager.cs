using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{

    public static int score = 0;
    public TMPro.TMP_Text scoretext;

    public static float timeRemaining = 100f;
    public TMPro.TMP_Text timetext;

    public static int star = 10;
    public TMPro.TMP_Text startext;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        star = 10;
        timeRemaining = 100f;
    }

    // Update is called once per frame
    void Update()
    {
        timeRemaining -= Time.deltaTime;
        scoretext.text = score.ToString();
        startext.text = star.ToString();
        timetext.text = ((int)timeRemaining).ToString();
	   if (star <= 0)
	   {

	    SceneManager.LoadScene("GameOver");
        Debug.Log("Game Over Scene Triggered");
	   }
       if (timeRemaining <= 0)
       {

            SceneManager.LoadScene("GameWon");
            Debug.Log("You've survive the swarm Time expired - You Won!");
       }
    }
}
