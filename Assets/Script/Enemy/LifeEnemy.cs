using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeEnemy : MonoBehaviour {

    public int life;

	// Use this for initialization
	void Awake () {
        if (gameObject.tag.Equals("Enemy"))
        {
            life = 2;
        }
        if (gameObject.tag.Equals("Mob"))
        {
            life = 4;
        }
	}

}
