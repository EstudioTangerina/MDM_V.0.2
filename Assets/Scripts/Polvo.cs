using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Polvo : MonoBehaviour
{
    public GameObject Marinheiro;
    public bool Perto;
    public bool IdlePolvo;
    public bool TintaPolvo;
    // Use this for initialization
    void Start()
    {
        Perto = false;
        IdlePolvo = false;
        TintaPolvo = true;
        StartCoroutine(Ballpusgo());
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Vector2.Distance(Marinheiro.transform.position, transform.position) < 10)
        {
            //GetComponent<Animator>().SetBool("Tinta", false);
            if (Perto == false)
            {
                Perto = true;
                GetComponent<Animator>().SetTrigger("Perto");
                GetComponent<Animator>().SetBool("PlayerPerto", true);
            }
        }
        else
        {
            if (Perto == true)
            {
                GetComponent<Animator>().SetTrigger("Longe");
                Perto = false;
                GetComponent<Animator>().SetBool("PlayerPerto", false);
                
            }
        }

    }
    IEnumerator Ballpusgo()
    {
        yield return new WaitForSeconds(3);
        GetComponent<Animator>().SetBool("Tinta", true);
        StopCoroutine(Ballpusgo());
        yield return new WaitForSeconds(9);
        GetComponent<Animator>().SetBool("Tinta", false);
        yield return new WaitForSeconds(2);
        GetComponent<Animator>().SetBool("Tinta", false);
        StartCoroutine(Ballpusgo());
    }

   void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag.Equals("Ancora"))
        {
            GetComponent<Animator>().SetTrigger("Damage");
        }
        print(coll);
    }
    /*{
        if(coll.gameObject.name == "Anchor")
        {
            GetComponent<Animator>().SetBool("Damage", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("Damage", false);
        }
        
    }*/
}
        
            
