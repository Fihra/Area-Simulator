using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiggerEnemyAI : MonoBehaviour
{
    private Transform myTransform;

    public float moveSpeed;
    public float minSpeed = 1.0f;
    public float maxSpeed = 2.0f;

    float x;
    float y = 10.0f, z = -1.0f;

    public static int health = 3;

    void Start()
    {
        x = Random.Range(-3.20f, 3.20f);
        myTransform = transform;
        myTransform.position = new Vector3(x, y, z);
        moveSpeed = Random.Range(minSpeed, maxSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        myTransform.Translate(Vector3.down * moveSpeed * Time.deltaTime);

        if (myTransform.position.y < -3.0f)
        {
            SpacePlayer.earthHealth -=3;
        }

        if (myTransform.position.y < -5.0f)
        {
            //change current speed
            //change the x axis
            moveSpeed = Random.Range(minSpeed, maxSpeed);
            x = Random.Range(-6.20f, 6.20f);
            myTransform.position = new Vector3(x, y, z);
            //Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other);
        if (other.gameObject.CompareTag("Projectile"))
        {
            //if the laser hits the enemy
            //destroy enemy
            health--;
            if(health < 1)
            {
                SpacePlayer.score += 3;
                Spawning.enemiesInArea.Remove(other.gameObject);
                //Debug.Log("Enemies in Area: " + Spawning.enemiesInArea.Count);
                Destroy(gameObject);
            }
            
        }

        if (other.gameObject.CompareTag("Player"))
        {
            if(health < 1)
            {
                Spawning.enemiesInArea.Remove(other.gameObject);
                Destroy(gameObject);
            }
            
        }

    }
}
