using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private Transform myTransform;

    public int health = 1000;
    bool isInvinsible = false;

    public float moveSpeed = 1;

    GameObject[] SmallAsteroids = new GameObject[10];
    GameObject[] BigAsteroids = new GameObject[6];

    public GameObject SmallAsteroid;
    public GameObject BigAsteroid;


    // Start is called before the first frame update
    void Start()
    {
        myTransform = transform;
        AssignAsteroids(SmallAsteroids, SmallAsteroid);
        AssignAsteroids(BigAsteroids, BigAsteroid);
        EnterCutScene();
        
    }

    void AssignAsteroids(GameObject[] asteroidCollection, GameObject asteroid)
    {
        for(int i=0; i < asteroidCollection.Length; i++)
        {
            asteroidCollection[i] = asteroid;
        }
    }

    public void EnterCutScene()
    {
        Debug.Log("In Cut Scene");
        Debug.Log(myTransform);
        myTransform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
        //do
        //{
            
        //} while (myTransform.position.y > 2.5f);

        //myTransform.position = new Vector3(myTransform.position.x, 2.5f, myTransform.position.z);
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



    // Update is called once per frame
    void Update()
    {
        
    }
}
