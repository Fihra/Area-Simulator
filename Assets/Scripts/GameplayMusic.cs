using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayMusic : MonoBehaviour
{
    Scene currentScene;

    public AK.Wwise.Event currentMusic;
    public AK.Wwise.State titleMusicState;

    enum levels
    {
        LEVEL_1 = 20,
        LEVEL_2 = 30,
        LEVEL_3 = 40,
        LEVEL_4 = 50
    }

    public List<AK.Wwise.State> levelMusicStates = new List<AK.Wwise.State>();

    void Awake()
    {
        currentScene = SceneManager.GetActiveScene();

        Debug.Log(currentScene.name == "SpaceShooter");
        if (currentScene.name == "MainMenu")
        {
            titleMusicState.SetValue();
            currentMusic.Post(gameObject);

        } 
        else if(currentScene.name == "SpaceShooter")
        {
            levelMusicStates[0].SetValue();
        }

    }

    void LevelMusic()
    {
        //Debug.Log("Current score: " + SpacePlayer.score);
        //Debug.Log(SpacePlayer.score > (int)levels.LEVEL_1);
        if ((SpacePlayer.score > (int)levels.LEVEL_1) && (SpacePlayer.score < (int)levels.LEVEL_2))
        {
            levelMusicStates[1].SetValue();
        }
        else if((SpacePlayer.score > (int)levels.LEVEL_2) && (SpacePlayer.score < (int)levels.LEVEL_3))
        {
            levelMusicStates[2].SetValue();
        }
        else if ((SpacePlayer.score > (int)levels.LEVEL_3) && (SpacePlayer.score < (int)levels.LEVEL_4))
        {
            levelMusicStates[3].SetValue();
        }


    }

    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        LevelMusic();
    }
}
