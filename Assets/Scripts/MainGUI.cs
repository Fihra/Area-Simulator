using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGUI : MonoBehaviour
{
    public float x = 50,y = 50, width = 400, height = 100;

    void OnGUI()
    {
        GUI.Box(new Rect(x, y, width, height), "Score: " + SpacePlayer.score + " Lives: " + SpacePlayer.playerLives);    
    }
}
