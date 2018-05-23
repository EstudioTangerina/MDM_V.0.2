using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Segue : MonoBehaviour {

    public GameObject player;

    void Update()
    {
        
            //player.transform.position.x < 50f
            if (player.transform.position.x > 0f && player.transform.position.x < 255f && player != null)
            {
                transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10f);
            }
            if (player.transform.position.y > 0 && player.transform.position.y < 255f & player != null)
            {
                transform.position = new Vector3(transform.position.x, player.transform.position.y, -10f);
            }
        
    }
}
        
