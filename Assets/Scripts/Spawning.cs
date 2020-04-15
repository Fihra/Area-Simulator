using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour
{
    public GameObject enemy;
    public Transform spawnLocation;

    public int enemyCount = 3;
    public int hordeMultiplier = 1;

    public static List<GameObject> enemiesInArea = new List<GameObject>();

    void Update()
    {
        if(enemiesInArea.Count < 3)
        {
            SpawnHorde();
        }
        
    }


    public void SpawnHorde()
    {
        enemyCount = enemyCount * hordeMultiplier;
        for(int i = 0; i < enemyCount; i++)
        {
            GameObject newEnem = Instantiate(enemy, spawnLocation.position, Quaternion.identity);
            enemiesInArea.Add(newEnem);
        }
    }
}
