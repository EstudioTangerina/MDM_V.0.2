using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Dead : MonoBehaviour
{

    public GameObject player;
    //public BoxCollider2D BoxCollieder;
    public GameObject PainelOver;
    private bool Cara;

    // Use this for initialization
    void Start()
    {
        PainelOver.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player");
        Cara = false;
    }

    // Update is called once per frame
    void Update()
    { 
        if(player.GetComponent<AcrPlayer>().life <= 0)
        {
            Cara = true;
            Debug.Log(Cara);
            PainelOver.SetActive(true);
            Destroy(player);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Dead")
        {
            Cara = true;
            Debug.Log(Cara);
            player.SetActive(false);
            PainelOver.SetActive(true);
        }
    }
}
