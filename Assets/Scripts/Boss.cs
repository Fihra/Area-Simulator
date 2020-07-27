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

    float timer;
    float cooldown = 3;
    bool attackActive = false;

    enum BossAttacks {Small = 0, Big = 1, Both = 2};

    int chooseAttack = 0;

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
        anim.SetBool("isLeftHand", true);
        

    }

    void BigAsteroidAttack()
    {
        anim.SetBool("isRightHand", true);
        

    }

    void DeflectAsteroidAttack()
    {
        anim.SetBool("isBothHands", true);
        

    }

    void MoveBoss()
    {

        Vector2 target;

        if(transform.position.y <= 2.5f)
        {
            target = new Vector2(playerTarget.position.x, 2.5f);
        }
        else
        {
            target = new Vector2(playerTarget.position.x, playerTarget.position.y);
        }

        
        Vector2 newPos = Vector2.MoveTowards(rb.position, target, moveSpeed * Time.deltaTime);
        rb.MovePosition(newPos);
    }

    void RandomAttack()
    {
        int rand = Random.Range(0, 3);
        Debug.Log(timer);

        while(rand == chooseAttack)
        {
            rand = Random.Range(0, 3);
        }
        chooseAttack = rand;

        if (!attackActive && timer <= 0)
        {
            timer = cooldown;

            attackActive = true;
            switch (chooseAttack)
            {
                case (int)BossAttacks.Small:
                    SmallAsteroidAttack();
                    return;
                case (int)BossAttacks.Big:
                    BigAsteroidAttack();
                    return;
                case (int)BossAttacks.Both:
                    DeflectAsteroidAttack();
                    return;
                default:
                    return;
            }
            
        }
        if(attackActive)
        {
            if(timer > 0)
            {
                timer -= Time.deltaTime;
            }
            else
            {
                attackActive = false;
                anim.SetBool("isLeftHand", false);
                anim.SetBool("isRightHand", false);
                anim.SetBool("isBothHands", false);
            }
            
        }
    }

    void Update()
    {
        MoveBoss();
        RandomAttack();
    }
}
