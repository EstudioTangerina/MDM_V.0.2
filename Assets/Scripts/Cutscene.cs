using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Cutscene : MonoBehaviour {

    //public GameObject SceneCut;
    public GameObject animObject;
    public Animator animAnimator;
    // Use this for initialization
    void Start () {
        animAnimator = animObject.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.name == "Body + Head")
        {
            animAnimator.SetBool("Cutscene", true);
        }
        /*if (coll.gameObject.name == "Body + Head")
        {
            SceneCut.SetActive(true);
            print("Ta funfando bro");
        }*/


    }
}
