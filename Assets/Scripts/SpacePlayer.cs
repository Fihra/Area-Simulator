using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpacePlayer : MonoBehaviour
{
    private Transform myTransform;

    public int playerSpeed = 5;
    public static int playerHealth = 10;
    public static int score = 0;

    public HealthManager healthBar;

    float timer = 0f;

    public Renderer rend;

    //variable to reference prefab. Prefab = gameObject to be reused

    public GameObject ProjectilePrefab;

    // Start is called before the first frame update
    void Start()
    {
        myTransform = transform;
        rend = GetComponent<Renderer>();
        healthBar.SetMaxHealth(playerHealth);
        //Spawn point
        //Position to be at -3, -3, -1 (x, y, z)
        myTransform.position = new Vector3(-1, -3, -1);

    }

    // Update is called once per frame
    void Update()
    {
        //Move the player left and right
        myTransform.Translate(Vector3.right * playerSpeed * Input.GetAxisRaw("Horizontal") * Time.deltaTime);

        //Make the player wrap
        // if the player is at x = -2, then it should appear at x=2. Vice Versa
        // if the player object is positioned at x=4.5, then the game object will be 
        // be positioned at x = -4.5

        if(myTransform.position.x > 6.5f)
        {
            myTransform.position = new Vector3(-6.5f, myTransform.position.y, myTransform.position.z);
        }

        else if(myTransform.position.x  < -6.5f)
        {
            myTransform.position = new Vector3(6.5f, myTransform.position.y, myTransform.position.z);
        }

        //Press Spacebar to fire a laser
        //If the player presses down the spacebar, a laser will shoot out.
        if(Input.GetKeyDown("space"))
        {
            //Set Position for Laser
            Vector3 laserPosition = new Vector3(myTransform.position.x, myTransform.position.y + 1, myTransform.position.z);

            //Fire Projectile
            Instantiate(ProjectilePrefab, laserPosition, Quaternion.identity);
        }

        if(Time.time - timer > 1)
        {
            rend.enabled = true;
        }

        //print("Lives: " + playerHealth + "   Score: " + score + "      Current Time: " + Time.time + "     Timer to respond: " + timer);
    }



    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            playerHealth--;
            healthBar.SetHealth(playerHealth);
            rend.enabled = false;
            timer = Time.time;
            if(playerHealth < 1)
            {
                Destroy(gameObject);
            }
            
        }
    }
}
