using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IlhasLiberadas : MonoBehaviour {

    public List<FreeIlhas> Ilhasliberadas = new List<FreeIlhas>();

    // Use this for initialization
    void Start() {
        
        for (int i = 1; i <= 8; i++)
        {

            switch(i)
            {
                case 1:
                    var Ilha1 = Resources.Load("Sprites/ilhas/ilha_4") as Sprite;
                    var Ilha2 = Resources.Load("Sprites/ilhas/ilha_9") as Sprite;
                    var Lib = false;
                    var il = new FreeIlhas(Ilha1, Ilha2, Lib);
                    Ilhasliberadas.Add(il);
                    break;
            }

            
            
        }
    
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

public class FreeIlhas
{
    public Sprite[] Sprites;
    public bool Liberada;

    public FreeIlhas(Sprite spr1, Sprite spr2, bool bule)
    {
        Sprites[0] = spr1;
        Sprites[1] = spr2;
        Liberada = bule;
    }
}
