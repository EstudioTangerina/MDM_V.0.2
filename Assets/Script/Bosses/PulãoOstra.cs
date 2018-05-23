using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulãoOstra : MonoBehaviour {

    public bool Foi = true;

    public GameObject Segue;

    Vector3 localScale;

    // Use this for initialization
    void Start () {
        localScale = transform.position - Segue.transform.position;
    }
	
	// Update is called once per frame
	void Update () {

        Foi = Segue.gameObject.GetComponent<PuloOstra>().Superpulo;
        transform.position = new Vector3(Segue.transform.position.x, transform.position.y, transform.position.z);

        if (Foi == true)
        {
                this.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1);         
        } else
        {   
                this.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);   
        }
    }
}
