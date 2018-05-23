using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trasiscao : MonoBehaviour {

    public GameObject[] Allposition;
    public int curPos;
    public float range;
    public Sprite[] states;
	// Use this for initialization
	void Start () {
        transform.position = Allposition[curPos].transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (range == 0)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow) && curPos < Allposition.Length - 1)
                curPos += 1;

            else if (Input.GetKeyDown(KeyCode.LeftArrow) && curPos >= 1)
                curPos -= 1;
        }
        range = Vector2.Distance(transform.position, Allposition[curPos].transform.position);

        Debug.Log(range);
        transform.position = Vector2.MoveTowards(transform.position, Allposition[curPos].transform.position, 3 * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Ilhas")
            GetComponent<SpriteRenderer>().sprite = states[1];
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.tag == "Ilhas")
            GetComponent<SpriteRenderer>().sprite = states[0];
    }
}
