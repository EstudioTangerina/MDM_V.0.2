using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivePlayer : MonoBehaviour {

    public int life;

    public Sprite[] states;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void LifePlayer()
    {
        if (life == 5)
        {
            GetComponent<SpriteRenderer>().sprite = states[0];
        }
        if (life == 4)
        {
            GetComponent<SpriteRenderer>().sprite = states[1];
        }
        if (life == 3)
        {
            GetComponent<SpriteRenderer>().sprite = states[2];
        }
        if (life == 2)
        {
            GetComponent<SpriteRenderer>().sprite = states[3];
        }
        if (life == 1)
        {
            GetComponent<SpriteRenderer>().sprite = states[4];
        }
        if (life == 0)
        {
            GetComponent<SpriteRenderer>().sprite = states[5];
        }

    }
}
