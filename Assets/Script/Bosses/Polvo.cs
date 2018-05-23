using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Polvo: MonoBehaviour {

    public static string Stado;
    public bool Atirou;
    public GameObject PlayerLOKO;
    public GameObject Polvao;
    public GameObject Life;


	// Use this for initialization
	void Start () {
        Atirou = false;
        StartCoroutine(Tiro());
    }
	
	// Update is called once per frame
	void Update () { 
        if (GetComponent<BarraVida>().FIll < 0f)
        {
            Polvao.SetActive(false);
            Life.SetActive(false);
            
        }

        if (Vector2.Distance(PlayerLOKO.transform.position, transform.position) < 5)
        {
            GetComponent<Animator>().SetBool("Atirou", false);

            if (Atirou == false)
            {
                Atirou = true;
                GetComponent<Animator>().SetTrigger("ChegouPer");
            }            
        }
        else
        {
            if (Atirou == true) {
                GetComponent<Animator>().SetTrigger("FoiLonge");
                Atirou = false;
                }
           
        }
	}
    IEnumerator Tiro()
    {
            yield return new WaitForSeconds(4);
            GetComponent<Animator>().SetBool("Atirou", true);
            Debug.Log("Chuchu");
        StopCoroutine(Tiro());
        yield return new WaitForSeconds(5);
        GetComponent<Animator>().SetBool("Atirou", false);
        yield return new WaitForSeconds(1);
        GetComponent<Animator>().SetBool("TerminouTiro", false);
        StartCoroutine(Tiro());
    }

    IEnumerator ParouTiro()
    {
        yield return new WaitForSeconds(5);
        
    }
    
}
