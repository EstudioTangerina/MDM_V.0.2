using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour {

    public Animator transcicaoAnim;
    public GameObject player;
    public BoxCollider2D Box;
    public string NomeScena;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}
    IEnumerator LoadScene()
    {
        transcicaoAnim.SetTrigger("End");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(NomeScena);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Complete")
        {
            StartCoroutine(LoadScene());
        }
    }
}
