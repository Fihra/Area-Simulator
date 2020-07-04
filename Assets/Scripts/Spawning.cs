using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyLevel {LEVEL1, LEVEL2, LEVEL3, LEVEL4, LEVEL5, LEVEL6 };

public class Spawning : MonoBehaviour
{
    public List <GameObject> enemies;
    public Transform spawnLocation;

    public int enemyCount = 3;
    public int hordeMultiplier = 1;

    //float x;
    //float y = 10.0f;

    EnemyLevel currentLevel = EnemyLevel.LEVEL1;

    public static List<GameObject> enemiesInArea = new List<GameObject>();

    void Update()
    {
        //Debug.Log("Enemies in Area: " + enemiesInArea.Count);
        if (enemiesInArea.Count <= 0)
        {
            SpawnHorde();
        } 
    }

    public void enemiesLevel1And2()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            GameObject newEnem = Instantiate(enemies[0], spawnLocation.position, Quaternion.identity);
            enemiesInArea.Add(newEnem);
        }
    }

    public void enemiesLevel3()
    {
        GameObject newBigEnem = Instantiate(enemies[1], spawnLocation.position, Quaternion.identity);
        enemiesInArea.Add(newBigEnem);
    }

    public void SpawnHorde()
    {
        //Level 2
        if(SpacePlayer.score >= 10 && SpacePlayer.score <= 50)
        {
            currentLevel = EnemyLevel.LEVEL2;
            enemyCount++;
            hordeMultiplier++;
        }
        //enemyCount = enemyCount * hordeMultiplier;
        enemiesLevel1And2();

        if(SpacePlayer.score >= 51 && SpacePlayer.score < 100)
        {
            currentLevel = EnemyLevel.LEVEL3;
            enemyCount++;
            hordeMultiplier++;
        }

        if(currentLevel == EnemyLevel.LEVEL3)
        {
            enemiesLevel3();
        }
    }
}
