using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    
    private Transform myTransform;
    public int projectileSpeed = 10;

    // Start is called before the first frame update
    void Start()
    {
        myTransform = transform;    
    }

    // Update is called once per frame
    void Update()
    {
        //Make the laser shoot out and go up
        // Game Object = laser = go up
        myTransform.Translate(Vector3.up * projectileSpeed * Time.deltaTime);

        if(myTransform.position.y > 10)
        {
            Destroy(gameObject);
        }
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            SpacePlayer.score += 1;
            Spawning.enemiesInArea.Remove(other.gameObject);
            Destroy(gameObject);
        }
    }
}
