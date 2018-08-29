using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivePlayer : MonoBehaviour {
    public ActionPlayer life;

    public Sprite[] states;


    // Use this for initialization
    void Start()
    {
        life = GameObject.FindGameObjectWithTag("Player").GetComponent<ActionPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        LifePlayer();
    }

    public void LifePlayer()
    {
        if (life.lifePlayer == 5)
        {
            GetComponent<SpriteRenderer>().sprite = states[0];
        }
        if (life.lifePlayer == 4)
        {
            GetComponent<SpriteRenderer>().sprite = states[1];
        }
        if (life.lifePlayer == 3)
        {
            GetComponent<SpriteRenderer>().sprite = states[2];
        }
        if (life.lifePlayer == 2)
        {
            GetComponent<SpriteRenderer>().sprite = states[3];
        }
        if (life.lifePlayer == 1)
        {
            GetComponent<SpriteRenderer>().sprite = states[4];
        }
        if (life.lifePlayer == 0)
        {
            GetComponent<SpriteRenderer>().sprite = states[5];
        }

    }
}
