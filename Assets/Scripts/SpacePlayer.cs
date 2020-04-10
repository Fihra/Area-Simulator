using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpacePlayer : MonoBehaviour
{
    private Transform myTransform;

    public int playerSpeed = 5;

    // Start is called before the first frame update
    void Start()
    {
        myTransform = transform;
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

        if(myTransform.position.x > 4.5f)
        {
            myTransform.position = new Vector3(-4.5f, myTransform.position.y, myTransform.position.z);
        }

        else if(myTransform.position.x  < -4.5f)
        {
            myTransform.position = new Vector3(4.5f, myTransform.position.y, myTransform.position.z);
        }
    }
}
