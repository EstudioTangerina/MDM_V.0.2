using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuloOstra : MonoBehaviour {

    float direçãoX;

    [SerializeField]
    float SeMove = 5f;

    public GameObject Ostra;

    Rigidbody2D rb;

    bool Pulando = true;

    bool Parou = false;

    public bool Superpulo;

    bool VoltaDireita = false;

    Vector3 localScale;

    // Use this for initialization
    void Start()
    {
        localScale = transform.localScale;
        rb = GetComponent<Rigidbody2D>();
        direçãoX = -1f;
        Superpulo = false;
        StartCoroutine(ParouPulo());
    }
    IEnumerator ParouPuloFast()
    {
        yield return new WaitForSeconds(2.5f);
        Pulando = false;
        Parou = true;
        print("ParouPuloFast");
        StartCoroutine(VoltAaPular());
    }
    IEnumerator ParouPulo()
    {
        yield return new WaitForSeconds(10);
        print("ParouPulo");
        Pulando = false;
        Parou = true;
        StartCoroutine(VoltAaPular());
    }
    IEnumerator VoltAaPular()
    {   
        yield return new WaitForSeconds(5);
        print("VoltAaPular");
        Pulando = true;
        Parou = false;
        StartCoroutine(SuperPulo());
        GetComponent<Animator>().SetBool("Fechado", false);
        GetComponent<Animator>().SetBool("Pulo", true);
    }
    IEnumerator SuperPulo()
    {
        yield return new WaitForSeconds(15);
        print("SuperPulo");
        Superpulo = true;
        GetComponent<Animator>().SetBool("Fechado", false);
        //rb.AddForce(Vector2.up * 900f );
        
        StopCoroutine(SuperPulo());
        StartCoroutine(ParouPuloFast());
    }
    void FixedUpdate() // Fica na tela
    {
        GetComponent<Animator>().SetFloat("Blend", rb.velocity.y);

        if (transform.position.x < -15f)
        {
            direçãoX = 1f;
        }
        else if (transform.position.x > 15f)
        {
            direçãoX = -1f;

        }
        if (Parou == false)
        {
            rb.velocity = new Vector2(direçãoX * SeMove, rb.velocity.y);
        }
        
    }

    void LateUpdate()
    {
        CheckWhereToFace();
        if(GetComponent<BarraVida>().FIll < 0.4)
        {
            SeMove = 10f;
        }
        if(GetComponent<BarraVida>().FIll < 0)
        {
            Ostra.SetActive(false);
            GetComponent<PulãoOstra>().Foi = false;
        }
    }

    void CheckWhereToFace() //Faz ele virar a Direção 
    {
        if (direçãoX > 0)
            VoltaDireita = true;
        else if (direçãoX < 0)
            VoltaDireita = false;

        if (((VoltaDireita) && (localScale.x > 0)) || ((!VoltaDireita) && (localScale.x < 0)))
            localScale.x *= -1;
    
        transform.localScale = localScale;
    }


   void OnCollisionEnter2D(Collision2D col) //Colisão com o chão (Entrando)
    {
        switch (col.gameObject.tag)
        {
            case "Floor":



                if (Parou == true && Pulando == false && Superpulo == false)
                {

                    GetComponent<Animator>().SetBool("Idle", true);
                    GetComponent<Animator>().SetBool("Pulo", false);
                 
                }

                if (Parou == false && Pulando == true && Superpulo == false)
                {
                    GetComponent<Animator>().SetBool("Pulo", true);
                    GetComponent<Animator>().SetBool("Idle", false);
                    //rb.AddForce(Vector2.up * 600f)
                }

                if (Parou == true && Pulando == false && Superpulo == true)
                {
                    GetComponent<Animator>().SetBool("Fechado", true);
                    Superpulo = false;

                }
                if (Parou == false && Pulando == true && Superpulo == true)
                {
                    rb.AddForce(Vector2.up * 900f);
                    print("Tei2");
                    
                }




                break;
        }
    }
    void OnCollisionStay2D(Collision2D col) //Colisão com o chão (Ficando)
    {
        switch (col.gameObject.tag)
        {

            case "Floor":
                if (Parou == true && Pulando == false && Superpulo == false && GetComponent<Animator>().GetBool("Fechado")==false)
                {

                    GetComponent<Animator>().SetBool("Idle", true);
                    GetComponent<Animator>().SetBool("Pulo", false);
                }

                if (Parou == false && Pulando == true && Superpulo == false)
                {
                    GetComponent<Animator>().SetBool("Pulo", true);
                    GetComponent<Animator>().SetBool("Idle", false);
                    if (rb.velocity.y == 0)
                    {   
                        rb.AddForce(Vector2.up * 600f);
                    }
                    
                }
               /*if (Parou == true && Pulando == false && Superpulo == true)
                {
                    GetComponent<Animator>().SetBool("Idle", false);

                }*/
                break;
        }
    }
}
