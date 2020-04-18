using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainGUI : MonoBehaviour
{
    //public float x = 50,y = 50, width = 400, height = 100;

    //void ongui()
    //{
    //    gui.box(new rect(x, y, width, height), "score: " + spaceplayer.score + " lives: " + spaceplayer.playerlives);    
    //}

    public static int scoreValue = 0;
    Text score;

    void Start()
    {
        score = GetComponent<Text>();    
    }

    void Update()
    {
        //score.text = "Score: " + scoreValue;
        score.text = $"Score: {SpacePlayer.score}";
    }
}
