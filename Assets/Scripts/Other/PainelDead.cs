using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PainelDead : MonoBehaviour {

    public string NomedaScena;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(NomedaScena);
        }

    }
}
