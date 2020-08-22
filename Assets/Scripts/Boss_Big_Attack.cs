using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Big_Attack : MonoBehaviour
{
    private Transform myTransform;
    int health = 3;

    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        myTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        myTransform.Translate(Vector3.down * moveSpeed * Time.deltaTime);

        if (myTransform.position.y < -8.0f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Projectile"))
        {
            health--;
            if(health < 1)
            {
                SpacePlayer.score += 3;
                Destroy(gameObject);
            }
        }

        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
