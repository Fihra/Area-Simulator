using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthBorder : MonoBehaviour
{
    public static int earthHealth = 1000;
    public EarthHealthManager earthHealthBar;

    // Start is called before the first frame update
    void Start()
    {
        earthHealthBar.SetEarthMaxHealth(earthHealth);
    }

    // Update is called once per frame
    void Update()
    {
        //if (myTransform.position.y < -3.0f && myTransform.position.y > -3.1f)
        //{
        //    SpacePlayer.earthHealth -= 100;

        //    Debug.Log(SpacePlayer.earthHealth);
        //}
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);
        if(other.gameObject.CompareTag("Enemy"))
        {
            earthHealth -= 1;
            earthHealthBar.SetHealth(earthHealth);
            Debug.Log(earthHealth);
        }
    }
}
