using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayMusic : MonoBehaviour
{
    Scene currentScene;

    public AK.Wwise.Event currentMusic;
    public AK.Wwise.State titleMusicState;

    public List<AK.Wwise.State> levelMusicStates = new List<AK.Wwise.State>();

    //public List<AK.Wwise.Event> levelMusic = new List<AK.Wwise.Event>();
    //AK.Wwise.Event currentMusic;

    void Awake()
    {
        currentScene = SceneManager.GetActiveScene();

        Debug.Log(currentScene.name == "SpaceShooter");
        if (currentScene.name == "MainMenu")
        {
            Debug.Log(titleMusicState);
            titleMusicState.SetValue();
            currentMusic.Post(gameObject);
            //currentMusic = titleMusic;
            //PlayTitleMusic();
            //currentMusic.Post(gameObject);
        } 
        else if(currentScene.name == "SpaceShooter")
        {
            LevelMusic();
            //currentMusic = levelMusic[0];
            //LevelMusic();
        }


    }

    void LevelMusic()
    {
        levelMusicStates[0].SetValue();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    //void PlayTitleMusic()
    //{
    //    currentMusic.Post(gameObject);
    //}

    //void LevelMusic()
    //{
    //    currentMusic.Post(gameObject);
    //}

    // Update is called once per frame
    void Update()
    {
        
    }
}
