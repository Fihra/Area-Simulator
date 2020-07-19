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
        LEVEL_1 = Spawning.EnemyLevel.LEVEL1,
        LEVEL_2 = Spawning.EnemyLevel.LEVEL2,
        LEVEL_3 = Spawning.EnemyLevel.LEVEL3,
        LEVEL_4 = Spawning.EnemyLevel.LEVEL4,
        LEVEL_FINAL = Spawning.EnemyLevel.LEVEL5
    }

    public List<AK.Wwise.State> levelMusicStates = new List<AK.Wwise.State>();

    void Awake()
    {
        currentScene = SceneManager.GetActiveScene();

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
        //if ((SpacePlayer.score > (int)levels.LEVEL_1) && (SpacePlayer.score < (int)levels.LEVEL_2))
        //{
        //    levelMusicStates[1].SetValue();
        //}
        //else if((SpacePlayer.score > (int)levels.LEVEL_2) && (SpacePlayer.score < (int)levels.LEVEL_3))
        //{
        //    levelMusicStates[2].SetValue();
        //}
        //else if ((SpacePlayer.score > (int)levels.LEVEL_3) && (SpacePlayer.score < (int)levels.LEVEL_4))
        //{
        //    levelMusicStates[3].SetValue();
        //}

        Spawning.EnemyLevel playing_level = Spawning.currentLevel;

        switch((int)playing_level)
        {
            case ((int)levels.LEVEL_2):
                levelMusicStates[1].SetValue();
                return;
            case ((int)levels.LEVEL_3):
                levelMusicStates[2].SetValue();
                return;
            case ((int)levels.LEVEL_4):
                levelMusicStates[3].SetValue();
                return;
            case ((int)levels.LEVEL_FINAL):
                levelMusicStates[4].SetValue();
                return;
            default:
                return;
        }

        //switch(SpacePlayer.score)
        //{
           
        //    case (int)levels.LEVEL_2:
        //        if(SpacePlayer.score >= (int)levels.LEVEL_2)
        //        {
        //            levelMusicStates[1].SetValue();
        //        }
        //        return;
        //    case (int)levels.LEVEL_3:
        //        if (SpacePlayer.score >= (int)levels.LEVEL_3)
        //        {
        //            levelMusicStates[2].SetValue();
        //        }
        //        return;
        //    case (int)levels.LEVEL_4:
        //        if (SpacePlayer.score >= (int)levels.LEVEL_4)
        //        {
        //            levelMusicStates[3].SetValue();
        //        }
        //        return;
        //    case (int)levels.LEVEL_FINAL:
        //        if (SpacePlayer.score >= (int)levels.LEVEL_FINAL && Spawning.enemiesInArea.Count == 0)
        //        {
        //            levelMusicStates[4].SetValue();
        //        }
        //        return;
        //    default:
        //        return;
        //}


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
