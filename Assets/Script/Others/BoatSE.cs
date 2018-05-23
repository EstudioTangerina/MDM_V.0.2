using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatSE : MonoBehaviour {

  public GameObject boat;

    void Update()
    {
        //player.transform.position.x < 50f
        /*if (boat.transform.position.x > 0f && boat.transform.position.x < 255f)
        {
            transform.position = new Vector3(boat.transform.position.x, boat.transform.position.y, -10f);
        }*/
        if (boat.transform.position.y > 0 && boat.transform.position.y < 255f)
        {
            transform.position = new Vector3(transform.position.x,boat.transform.position.y, -10f);
        }
    }
}
