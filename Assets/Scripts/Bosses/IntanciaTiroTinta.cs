using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntanciaTiroTinta : MonoBehaviour {

    public float speed;

    private Transform Segue;
    //public GameObject Jogador;
   // public GameObject Painel;
    private Vector2 target;

    void Start()
    {
        Segue = GameObject.FindGameObjectWithTag("Player").transform;

        target = new Vector2(Segue.position.x , Segue.position.y);
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            DestroyProjectile();
        }

    }

    void OnTriggerEnter2D(Collider2D cool)
    {
        if (cool.CompareTag("Player"))
        {
            DestroyProjectile();
        }
        /*if (cool.gameObject.tag == "Player")
        {
            Debug.Log("aasdasdsad");
            GameObject.FindGameObjectWithTag("LifePlayer").GetComponent<PerdeLive>().LifePlayer();
            GameObject.FindGameObjectWithTag("LifePlayer").GetComponent<PerdeLive>().life -= 1;
            DestroyProjectile();

        }*/
    }


    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
