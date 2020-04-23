using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSFX : MonoBehaviour
{
    public AK.Wwise.Event asteroidExplode;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Projectile") || other.gameObject.CompareTag("Player"))
        {
            asteroidExplode.Post(gameObject);
        }
    }
}
