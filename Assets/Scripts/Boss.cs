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

    public AK.Wwise.Event Ouchies;

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
        Debug.Log("Smol Atk");
        //Vector3 currentPosition = new Vector3(myTransform.position.x, myTransform.position.y, myTransform.position.z);
        Vector3 currentPosition = myTransform.GetChild(0).localPosition;
        Debug.Log(currentPosition);
        //for(int i=0; i < SmallAsteroids.Length; i++)
        //{
        //    if (i >= 4)
        //    {

        //    }
        //    else
        //    {
        //        Instantiate(SmallAsteroids[i], currentPosition, Quaternion.identity);
        //    }
        //}
        Instantiate(SmallAsteroids[0], currentPosition, Quaternion.identity);
        Instantiate(SmallAsteroids[1], new Vector3(currentPosition.x + 2.5f, currentPosition.y, currentPosition.z), Quaternion.identity);
        Instantiate(SmallAsteroids[2], new Vector3(currentPosition.x - 1.5f, currentPosition.y, currentPosition.z), Quaternion.identity);
        Instantiate(SmallAsteroids[3], new Vector3(currentPosition.x - 3.5f, currentPosition.y, currentPosition.z), Quaternion.identity);



    }

    void BigAsteroidAttack()
    {
        anim.SetBool("isRightHand", true);
        Vector3 currentPosition = myTransform.GetChild(1).localPosition;
        Instantiate(BigAsteroids[0], currentPosition, Quaternion.identity);
    }

    void DeflectAsteroidAttack()
    {
        anim.SetBool("isBothHands", true);
        

    }

    void MoveBoss()
    {

        Vector2 target;

        if(transform.position.y <= 3.47f)
        {
            target = new Vector2(playerTarget.position.x, 3.47f);
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
        //Debug.Log(timer);

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

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(health);
        if(other.gameObject.CompareTag("Projectile"))
        {
            health--;
            Ouchies.Post(gameObject);
        }
    }
}
