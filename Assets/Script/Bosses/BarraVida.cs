using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BarraVida : MonoBehaviour {
    public Image Bar;
    public float FIll;
    public GameObject arpao;
    
    void Start()
    {
        FIll = 1f;
    }

    void Update()
    {

    }
    void OnCollisionEnter2D(Collision2D cool)
    {
        if (cool.gameObject.tag.Equals(" Harpoon"))
        {
            FIll -= 0.1f;
            Bar.fillAmount = FIll;
        }
    }
}
     

        

        


