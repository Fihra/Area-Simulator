using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private Transform myTransform;
    private Animator anim;

    public int health = 1000;
    bool isInvinsible = false;
    bool cutsceneDone = false;

    public float enterSpeed = 1.0f;
    public float moveSpeed = 2.0f;

    GameObject[] SmallAsteroids = new GameObject[10];
    GameObject[] BigAsteroids = new GameObject[6];

    public GameObject SmallAsteroid;
    public GameObject BigAsteroid;

    Transform playerTarget;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        myTransform = transform;
        anim = transform.GetComponent<Animator>();
        
        AssignAsteroids(SmallAsteroids, SmallAsteroid);
        AssignAsteroids(BigAsteroids, BigAsteroid);

        playerTarget = GameObject.FindGameObjectWithTag("Player").transform;
        rb = transform.GetComponent<Rigidbody2D>();

    }

    void AssignAsteroids(GameObject[] asteroidCollection, GameObject asteroid)
    {
        for(int i=0; i < asteroidCollection.Length; i++)
        {
            asteroidCollection[i] = asteroid;
        }
    }

    void SmallAsteroidAttack()
    {

    }

    void BigAsteroidAttack()
    {

    }

    void DeflectAsteroidAttack()
    {

    }

    void MoveBoss()
    {
        //Vector3 targetPosition = new Vector3(playerTarget.position.x, transform.position.y, transform.position.z);

        //transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        Vector2 target;

        if(transform.position.y <= 2.5f)
        {
            target = new Vector2(playerTarget.position.x, 2.5f);
        }
        else
        {
            target = new Vector2(playerTarget.position.x, playerTarget.position.y);
        }

        
        //Vector2 newPos = Vector2.MoveTowards(rb.position, target, moveSpeed * Time.deltaTime);
        //rb.MovePosition(newPos);
        Debug.Log(rb);
        Debug.Log(target);
        Vector2 newPos = Vector2.MoveTowards(rb.position, target, moveSpeed * Time.deltaTime);
        //rb.velocity = newPos;
        rb.MovePosition(newPos);
    }


    // Update is called once per frame
    void Update()
    {
        MoveBoss();
        //anim.SetBool("isMoving", true);



    }

}
