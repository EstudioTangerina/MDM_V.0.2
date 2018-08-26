using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSeguindo : MonoBehaviour {

    public GameObject player;
    public float MaxCamSegue;

    void Start()
    {
        transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
    }

    void Update()
    {

        //player.transform.position.x < 50f
        if (player.transform.position.x > 0f && player.transform.position.x < MaxCamSegue && player != null)
        {
            transform.position = new Vector3(player.transform.position.x, transform.position.y, -10f);
        }
        /*if (player.transform.position.y > 0 && player.transform.position.y < MaxCamSegue & player != null)
        {
            transform.position = new Vector3(transform.position.x, player.transform.position.y, -10f);
        }*/

    }
}
