using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private Transform myTransform;

    public float moveSpeed;
    public float minSpeed = 1.0f;
    public float maxSpeed = 3.0f;

    float x;
    float y = 10.0f, z = -1.0f;

    //public GameObject EnemyProjectile;

    //float spawnLocation;

    // Start is called before the first frame update
    void Start()
    {
        x = Random.Range(-6.20f, 6.20f);
        myTransform = transform;
        myTransform.position = new Vector3(x, y, z);
        moveSpeed = Random.Range(minSpeed, maxSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        myTransform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
        
        if(myTransform.position.y < -7.0f)
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
            Spawning.enemiesInArea.Remove(other.gameObject);
            Debug.Log("Enemies in Area: " + Spawning.enemiesInArea.Count);
            Destroy(gameObject);
        }
        
        if(other.gameObject.CompareTag("Player"))
        {
            Spawning.enemiesInArea.Remove(other.gameObject);
            Debug.Log("Enemies in Area: " + Spawning.enemiesInArea.Count);
            Destroy(gameObject);
        }

    }
}
