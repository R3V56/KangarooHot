using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Manager : MonoBehaviour
{
    public static int score = 0;
    public TMPro.TMP_Text scoretext;

    public static int star = 10;
    public TMPro.TMP_Text startext;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        star = 10;
    }

    // Update is called once per frame
    void Update()
    {
        scoretext.text = score.ToString();
        startext.text = star.ToString();
    }
}
