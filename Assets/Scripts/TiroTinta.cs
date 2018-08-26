using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroTinta : MonoBehaviour {
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;

    private float timeBtwShots;
    public float startTimeBtwShots;

    public GameObject Tinta;
    private Transform Marinheiro;

    // Use this for initialization
    void Start()
    {
        Marinheiro = GameObject.FindGameObjectWithTag("Player").transform;

        timeBtwShots = startTimeBtwShots;

    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Polvo>().TintaPolvo == true) {
            if (Vector2.Distance(transform.position, Marinheiro.position) > stoppingDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, Marinheiro.position, speed * Time.deltaTime);
            }
            else if (Vector2.Distance(transform.position, Marinheiro.position) < stoppingDistance && Vector2.Distance(transform.position, Marinheiro.position) > retreatDistance)
            {
                transform.position = this.transform.position;
            }
            else if (Vector2.Distance(transform.position, Marinheiro.position) < retreatDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, Marinheiro.position, -speed * Time.deltaTime);
            }



            if (timeBtwShots <= 0)
            {
                Instantiate(Tinta, transform.position, Quaternion.identity);
                timeBtwShots = startTimeBtwShots;
            }
            else
            {

                timeBtwShots -= Time.deltaTime;
            }
        }

    }
}
