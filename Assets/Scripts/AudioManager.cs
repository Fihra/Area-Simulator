using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public AK.Wwise.Event bgmEvent;

    Scene currentScene;

    // Start is called before the first frame update
    void Start()
    {
        bgmEvent.Post(gameObject); 
        currentScene = SceneManager.GetActiveScene();
    }

    void ChangeMusic()
    {   
        switch(currentScene.name)
        {
            //case "MainMenu":
            //    bgmEvent.Post(gameObject);
            //    return;
            case "SpaceShooter":
                bgmEvent.Stop(gameObject);
                Destroy(gameObject);
                return;
            default:
                return;
        }

    }

    // Update is called once per frame
    void Update()
    {
        //Destroy(gameObject, 5f);
        ChangeMusic();
        //Debug.Log(currentScene.name);
        //if(currentScene.name != "MainMenu")
        //{
            
        //}
    }
}
