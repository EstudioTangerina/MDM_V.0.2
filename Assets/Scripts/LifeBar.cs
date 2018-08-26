using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour
{
    public Image FullLife;
    public Image NoLife;
    public float Fill;
    public GameObject Boss;
    public bool Dano;
    //public GameObject arpao;

    void Start()
    {
        Fill = 1f;
        Dano = false;
    }

    void Update()
    {
        if (Fill < 0)
        {
            NoLife.enabled = false;
            StartCoroutine(Morreu());
        }
        if (Boss == false)
        {
            GetComponent<Cutscene>().LoadScene();
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Anchor"))
        {
            Fill -= 0.01f;
            FullLife.fillAmount = Fill;
            Dano = true;
            StartCoroutine(Polvo());
            
        }
    }
    IEnumerator Polvo()
    {
        yield return new WaitForSeconds(0.1f);
        if (Dano == true)
        {
            GetComponent<Polvo>().GetComponent<Animator>().SetBool("Damage", true);
            GetComponent<Polvo>().TintaPolvo = false;

        }
        yield return new WaitForSeconds(2);
        Dano = false;
        GetComponent<Polvo>().GetComponent<Animator>().SetBool("Damage", false);
        GetComponent<Polvo>().GetComponent<Animator>().SetBool("PlayerPerto", false);
        GetComponent<Polvo>().TintaPolvo = true;
        StopCoroutine(Polvo());
    }
    IEnumerator Morreu()
    {
        yield return new WaitForSeconds(5);
        Boss.SetActive(false);
        StopCoroutine(Morreu());
    }
}
