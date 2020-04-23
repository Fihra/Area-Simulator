using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayMusic : MonoBehaviour
{
    public List<AK.Wwise.Event> levelMusic = new List<AK.Wwise.Event>();
    AK.Wwise.Event currentMusic;

    void Awake()
    {
         
    }

    // Start is called before the first frame update
    void Start()
    {
        currentMusic = levelMusic[0];
        currentMusic.Post(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
