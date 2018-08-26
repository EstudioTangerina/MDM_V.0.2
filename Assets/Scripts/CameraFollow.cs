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
        transform.position = Player.transform.position + offset;
        transform.position = new Vector3(Player.transform.position.x, transform.position.y, transform.position.z);
        /*if (Player.transform.position.x > 0f && Player.transform.position.x < MaxCamSegue && Player != null)
        {
            transform.position = new Vector3(Player.transform.position.x, transform.position.y, -10f);
        }*/
    }
}
