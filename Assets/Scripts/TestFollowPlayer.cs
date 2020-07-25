using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestFollowPlayer : MonoBehaviour
{
    private Transform playerPos;
    public float speed = 2.5f;
    // Start is called before the first frame update
    void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, playerPos.position, speed * Time.deltaTime);
    }
}
