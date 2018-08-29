using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Polvo : MonoBehaviour
{
    public GameObject Marinheiro;
    public bool Perto;
    public bool IdlePolvo;
    public bool TintaPolvo;

    public GameObject animObject;
    public Animator animAnimator;
    public string NomeScena;
    // Use this for initialization
    void Start()
    {
        animAnimator = animObject.GetComponent<Animator>();
        Perto = false;
        IdlePolvo = false;
        TintaPolvo = false;
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
                //StartCoroutine(TimeDePerto());
            }
        }
        else
        {
            if (Perto == true)
            {
                GetComponent<Animator>().SetTrigger("Longe");
                Perto = false;
                GetComponent<Animator>().SetBool("PlayerPerto", false);
                TintaPolvo = true;
                
            }
        }

        if(GetComponent<LifeBar>().Fill < 0)
        {
            GetComponent<Animator>().SetBool("Morreu", true);
            TintaPolvo = false;
            StartCoroutine(LoadScene());
        }

    }
   public IEnumerator Ballpusgo()
    {
        yield return new WaitForSeconds(3);
        GetComponent<Animator>().SetBool("Tinta", true);
        TintaPolvo = true;
        StopCoroutine(Ballpusgo());
        yield return new WaitForSeconds(9);
        GetComponent<Animator>().SetBool("Tinta", false);
        yield return new WaitForSeconds(2);
        GetComponent<Animator>().SetBool("Tinta", false);
        TintaPolvo = false;
        StartCoroutine(Ballpusgo());
    }
    IEnumerator TimeDePerto()
    {
        yield return new WaitForSeconds(3);
        GetComponent<Animator>().SetBool("PlayerPerto", true);
        TintaPolvo = false;
        StopCoroutine(TimeDePerto());
        print(TimeDePerto());
    }
    IEnumerator LoadScene()
    {
        animAnimator.SetBool("LevelComplete", true);
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(NomeScena);
    }
}
        
            
