using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float MoveSpeed;

    private Animator mAnimator;

    public LayerMask mask;

    void Start()
    {
        mAnimator = GetComponent<Animator>();    
    }

    void FixedUpdate()
    {
  
        PlayerMovement();

        
    }

    void PlayerMovement()
    {
        float hor = Input.GetAxisRaw("Horizontal");
        float ver = Input.GetAxisRaw("Vertical");
        Vector3 playerMove = new Vector3(hor, 0f, ver) * MoveSpeed * Time.deltaTime;
        RabbitAnimation();
        
        transform.Translate(playerMove, Space.Self);
    }

    void GetAlignment()
    {
        RaycastHit hit;

        Physics.Raycast(transform.position, -transform.up, out hit, 0.7f, mask);

        Vector3 newUp = hit.normal;

        transform.up = newUp;
    }

    void RabbitAnimation()
    {
        bool running = Input.GetKey(KeyCode.W);
        mAnimator.SetBool("running", running);
        GetAlignment();
    }

}
