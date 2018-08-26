using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cutscene : MonoBehaviour {

    //public GameObject SceneCut;
    public GameObject animObject;
    public Animator animAnimator;
    public string NomeScena;
    // Use this for initialization
    void Start () {
        animAnimator = animObject.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
   public IEnumerator LoadScene()
    {
        animAnimator.SetBool("LevelComplete", true);
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(NomeScena);
    }
    private void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.name == "Body + Head")
        {
            animAnimator.SetBool("Cutscene", true);
        }

        /*if (coll.gameObject.name == "Body + Head")
        {
            SceneCut.SetActive(true);
            print("Ta funfando bro");
        }*/

        if (coll.gameObject.name == "Body + Head")
        {
            //animAnimator.SetBool("LevelComplete", true);
            StartCoroutine(LoadScene());
        }
    }
}
