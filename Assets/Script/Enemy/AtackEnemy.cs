using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtackEnemy : MonoBehaviour {

    private int damage;

    private GameObject player;

    private bool isatac;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        isatac = false;
    }

    void Damage()
    {
        player.GetComponent<AcrPlayer>().life -= damage;
    }

    public IEnumerator Atac()
    {
        isatac = true;
        StopCoroutine(Atac());
        yield return new WaitForSeconds(1f);
        isatac = false;
    }

    void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.tag.Equals("Player"))
        {
            if (isatac == false)
            {
                StartCoroutine(Atac());
            }
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag.Equals("Player"))
        {
            Damage();
        }
    }
}
