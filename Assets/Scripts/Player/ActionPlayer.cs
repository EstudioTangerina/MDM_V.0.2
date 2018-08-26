using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine;
using UnityEngine.UI;

public class ActionPlayer : MonoBehaviour
{
    private float speed;
    public float jumpSpeed = 5.5f;
    public float Velocidade = 1.0F;
    private float startTime;
    private float journeyLength;

    private bool isGrounded = true;
    private bool andou = false;
    public bool passou = true;

    public GameObject aguaAtras;

    private Rigidbody2D rb;

    private Animator anim;

    private int timeJump;
	public int lifePlayer;

    public Transform startMarker;
    public Transform endMarker;

	public Slider sliderHealth;

    void Start()
    {
        journeyLength = Vector3.Distance(startMarker.position, endMarker.position);

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        startTime = Time.time;

        speed = 3.5f;

        timeJump = 3;
		lifePlayer = 5;
    }

    void Update()
    {
        Ataque();

		Died();
    }

    void FixedUpdate()
    {
        moviment();

        if (isGrounded == false) anim.SetBool("Pulando", true);
        else anim.SetBool("Pulando", false);
        anim.SetFloat("Blend", rb.velocity.y);
    }

    void moviment()
    {
            anim.SetFloat("Speed", Mathf.Abs(Input.GetAxisRaw("Horizontal")));

        
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                transform.position += Vector3.right * speed * Time.deltaTime;
                transform.eulerAngles = new Vector2(0, 0);
            }
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                transform.position += Vector3.left * speed * Time.deltaTime;
                transform.eulerAngles = new Vector2(0, 180);
            }


            if (Input.GetKeyDown(KeyCode.UpArrow) && timeJump < 2 || Input.GetKeyDown(KeyCode.W) && timeJump < 2)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
                timeJump++;
                isGrounded = false;
            }
        
 
    }
    void Ataque()
    {
        if (Input.GetKey(KeyCode.H))
        {
            anim.SetBool("AtaqueLeve", true);
        }
        else
        {
            anim.SetBool("AtaqueLeve", false);
        }

        if (Input.GetKey(KeyCode.J))
        {
            anim.SetBool("AtaquePesado", true);
        }
    }

	void Died()
	{
		if (lifePlayer <= 0)
		{
			Destroy(this.gameObject);
		}
	}

	#region EndAnim

	public void EndAtckPesado()
    {
        anim.SetBool("AtaquePesado", false);
    }
    #endregion

     void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Chao")
        {
            timeJump = 0;
            isGrounded = true;
        }
    }
     void OnTriggerEnter2D(Collider2D Collo)
    {
        if (Collo.gameObject.name == "AguaAtras")
        {
            aguaAtras.GetComponent<Tilemap>().color = new Color(255, 255, 255, 0.7137255f);  
        }
        /*if (Collo.gameObject.name == "Anchor")
        {
            GameObject.FindGameObjectWithTag("LifeBoss").GetComponent<LifeBar>().LifeDoBoss();
            GameObject.FindGameObjectWithTag("LifeBoss").GetComponent<LifeBar>().LifeBosses -= 1;
        }*/
    }
     void OnTriggerExit2D(Collider2D collAguaExit)
    {
         if (collAguaExit.gameObject.name == "AguaAtras")
        {
            aguaAtras.GetComponent<Tilemap>().color = new Color(255, 255, 255, 1f);
        }
    }
     void OnTriggerStay2D(Collider2D colliComplete)
    {
        if(colliComplete.gameObject.name == "Level Complete")
        {
            float distCovered = (Time.time - startTime) * Velocidade;
            float fracJourney = distCovered / journeyLength;
            transform.position = Vector3.Lerp(startMarker.position, endMarker.position, fracJourney);

        }
    }

}
