using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour
{
    public GameObject enemy;
    public Transform spawnLocation;

    public int enemyCount = 3;
    public int hordeMultiplier = 1;

    //float x;
    //float y = 10.0f;

    public static List<GameObject> enemiesInArea = new List<GameObject>();

    void Update()
    {

        Debug.Log("Enemies in Area: " + enemiesInArea.Count);
        if (enemiesInArea.Count <= 0)
        {
            SpawnHorde();
        }

        
        
    }


    public void SpawnHorde()
    {
        if(SpacePlayer.score >= 10 && SpacePlayer.score <= 50)
        {
            enemyCount++;
            hordeMultiplier = 2;
        }
        //enemyCount = enemyCount * hordeMultiplier;
        for (int i = 0; i < enemyCount; i++)
        {
            GameObject newEnem = Instantiate(enemy, spawnLocation.position, Quaternion.identity);
            enemiesInArea.Add(newEnem);
        }
    }
}
