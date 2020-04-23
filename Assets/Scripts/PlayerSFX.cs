using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSFX : MonoBehaviour
{
    public AK.Wwise.Event playerShoot;
    public AK.Wwise.Event playerDamage;
    public AK.Wwise.Event playerDeath;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("space"))
        {
            playerShoot.Post(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            if(SpacePlayer.playerHealth < 1)
            {
                playerDeath.Post(gameObject);
            }
            else
            {
                playerDamage.Post(gameObject);
            }
            
        }
    }
}
