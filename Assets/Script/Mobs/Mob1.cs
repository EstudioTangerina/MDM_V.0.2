using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Mob1 : MonoBehaviour {
    public float walkSpeed = 2.0f;      // Walkspeed
    public float wallLeft =2.2f;       // Define wallLeft
    public float wallRight = 20f;      // Define wallRight
    float walkingDirection = 1.0f;
    Vector2 walkAmount;
    float originalX; // Original float value

    public GameObject player;
    public GameObject enemy;


    void Start()
    {
        this.originalX = this.transform.position.x;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
        walkAmount.x = walkingDirection * walkSpeed * Time.deltaTime;
        if (walkingDirection > 0.0f && transform.position.x >= wallRight)
        {
            walkingDirection = -1.0f;
        }
        else if (walkingDirection < 0.0f && transform.position.x <= wallLeft)
        {
            walkingDirection = 1.0f;
        }
        transform.Translate(walkAmount);
        transform.localScale = new Vector3(-walkingDirection,1,1);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag.Equals("Player"))
        {
            player.GetComponent<AcrPlayer>().life -= 1;
            StartCoroutine(player.GetComponent<AcrPlayer>().Knockback(0.02f, 350f , player.transform.position));
        }
    }

}



