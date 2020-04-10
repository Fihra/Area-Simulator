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
        myTransform.position = new Vector3(-3, -3, -1);

    }

    // Update is called once per frame
    void Update()
    {
        //Move the player left and right
        myTransform.Translate(Vector3.right * playerSpeed * Input.GetAxisRaw("Horizontal") * Time.deltaTime);
    }
}
