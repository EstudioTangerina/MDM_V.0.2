using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    private GameObject Player;
    public float MaxCamSegue;
    public Vector3 offset;
    void Start () {
        Player = GameObject.FindGameObjectWithTag("Player");
        offset = transform.position - Player.transform.position;
        transform.position = new Vector3(Player.transform.position.x, transform.position.y, transform.position.z);
	}
	
	void LateUpdate () {

		if(Player != null && transform.position.x < 205.8f)
		{
        transform.position = Player.transform.position + offset;
        transform.position = new Vector3(Player.transform.position.x, transform.position.y, transform.position.z);
		}
        else
        {
            Vector3 f = new Vector3(transform.position.x, 13.678f, transform.position.z);

            transform.position = Vector3.Lerp(transform.position, f, 3 * Time.deltaTime);


        }
    }
}