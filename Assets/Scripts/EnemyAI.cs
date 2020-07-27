using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private Transform myTransform;

    public float moveSpeed;
    public static float minSpeed = 1.0f;
    public static float maxSpeed = 3.0f;

    float x;
    float y = 10.0f, z = -1.0f;

    Spawning.EnemyLevel newEnemyLevel;
    Spawning.EnemyLevel currentEnemyLevel;

    //public GameObject EnemyProjectile;
    //float spawnLocation;

    void Start()
    {
        newEnemyLevel = Spawning.currentLevel;
        currentEnemyLevel = newEnemyLevel;

        x = Random.Range(-6.20f, 6.20f);
        myTransform = transform;
        myTransform.position = new Vector3(x, y, z);
        moveSpeed = Random.Range(minSpeed, maxSpeed);
    }

    void Update()
    {
        myTransform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
        
        if(myTransform.position.y < -7.0f)
        {
            //change current speed
            //change the x axis
            //Debug.Log("CurrentLevel: " + currentEnemyLevel);
            //Debug.Log("newLevel: " + newEnemyLevel);
            if(currentEnemyLevel != newEnemyLevel)
            {
                minSpeed += 0.25f;
                maxSpeed += 0.25f;
            }

            moveSpeed = Random.Range(minSpeed, maxSpeed);
            x = Random.Range(-6.20f, 6.20f);
            myTransform.position = new Vector3(x, y, z);
            
            //Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Projectile") || other.gameObject.CompareTag("Player"))
        {
            //if the laser hits the enemy
            //destroy enemy
            Destroy(gameObject);
        }
    }
}
