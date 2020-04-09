using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 1. 8 directional movement
/// 2. stop and face current direction when input is absent
/// </summary>
public class MovementController : MonoBehaviour
{
    public float velocity = 5;
    public float turnSpeed = 10;

    //x for horizontal
    //y for vertical
    Vector2 input;

    //current angle
    //know how to rotate the player
    float angle;

    Quaternion targetRotation;
    Transform cam;

    void Start()
    {
        cam = Camera.main.transform;    
    }

    void Update()
    {
        GetInput();

        //Stop and face current direction
        if (Mathf.Abs(input.x) < 1 && Mathf.Abs(input.y) < 1) return;
        CalculateDirection();
        Rotate();
        Move();
         
    }

    /// <summary>
    /// Input based on Horizontal(a, d, < >) and Vertical(w, s, ^, v) keys
    /// </summary>
    void GetInput()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
    }

    /// <summary>
    /// Direction relative to the camera's rotation
    /// </summary>
    void CalculateDirection()
    {
        angle = Mathf.Atan2(input.x, input.y);
        angle = Mathf.Rad2Deg * angle;
        angle += cam.eulerAngles.y;

    }

    /// <summary>
    /// Rotate toward the calculated angle
    /// </summary>
    void Rotate()
    {
        targetRotation = Quaternion.Euler(0, angle, 0);
        //current rotation, target rotation, how fast you want to go
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
    }

    /// <summary>
    /// This player only moves along its own forward axis
    /// </summary>
    void Move()
    {
        transform.position += transform.forward * velocity * Time.deltaTime;
    }

}
