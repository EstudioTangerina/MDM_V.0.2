using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoBullet : MonoBehaviour {

    private float moveBullet;

    private GameObject player;
    private GameObject enemy;

    private bool glued;


    void Start()
    {
        moveBullet = 40f;

        player = GameObject.FindGameObjectWithTag("Player");

        enemy = GameObject.FindGameObjectWithTag("Enemy");

        glued = false;

        if (player.transform.localScale.x < 0)
        {
            moveBullet = moveBullet * -1;
        }
    }
   
    void Update()
    {
        GoBulletGo();
    }

    void GoBulletGo()
    {
        if (glued == false)
            transform.Translate(moveBullet * Time.deltaTime, 0, 0);
    }

    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
        player.GetComponent<AcrPlayer>().cantshot = false;
        player.GetComponent<AcrPlayer>().count = true;
    }

    void Damage(Collision2D ColliderEnemy)
    {
        enemy = ColliderEnemy.gameObject;
        enemy.GetComponent<LifeEnemy>().life -= 1;
    }

    public void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag.Equals("Enemy") || coll.gameObject.tag.Equals("Mob"))
        {
            glued = true;
            player.GetComponent<AcrPlayer>().other = coll.gameObject;
            Damage(coll);
            player.GetComponent<AcrPlayer>().count = false;
            player.GetComponent<AcrPlayer>().inst.transform.parent = coll.gameObject.transform;

            
            if (enemy.GetComponent<LifeEnemy>().life <= 0)
            {
                player.GetComponent<AcrPlayer>().inst.transform.parent = null;
                player.GetComponent<AcrPlayer>().inst.GetComponent<BoxCollider2D>().isTrigger = true;
                player.GetComponent<AcrPlayer>().podevoltar = true;
                Destroy(enemy);
            }
                
        }

        if (coll.gameObject.tag.Equals("Floor"))
        {
            glued = true;
            player.GetComponent<AcrPlayer>().count = false;
        }
        if (coll.gameObject.tag.Equals("Player"))
        {
            player.GetComponent<AcrPlayer>().count = true;
            player.GetComponent<AcrPlayer>().podevoltar = false;
            Destroy(this.gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag.Equals("Player"))
        {
            player.GetComponent<AcrPlayer>().count = true;
            player.GetComponent<AcrPlayer>().podevoltar = false;
            Destroy(this.gameObject);
        }
    }
}
