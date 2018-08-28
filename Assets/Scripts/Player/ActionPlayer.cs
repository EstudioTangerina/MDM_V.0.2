using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;
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
    public bool atacou = false;
    public bool passou = true;
    public bool Funciona = true;
    public bool Pisca = false;


    public GameObject aguaAtras;
    public GameObject Player;

    private Rigidbody2D rb;

    private Animator anim;

    private int timeJump;
	public int lifePlayer;

    public Transform startMarker;
    public Transform endMarker;

	public Slider sliderHealth;
    bool andar;
    void Start()
    {
        //if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("SampleManager"))
        if(startMarker != null && endMarker != null)
        {
            journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
        }

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        startTime = Time.time;

        speed = 3.5f;

        timeJump = 3;
		lifePlayer = 7;
    }

    void Update()
    {
        Ataque();

        if(andar)
        {
            float d = Vector2.Distance(transform.position, endMarker.position);

            if (d > 0)
                transform.position = Vector2.MoveTowards(transform.position, endMarker.position, 5 * Time.deltaTime);

            else
                andar = false;
        }

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
            atacou = true;
        }
        else
        {
            anim.SetBool("AtaqueLeve", false);
            atacou = false;
        }

        if (Input.GetKey(KeyCode.J))
        {
            anim.SetBool("AtaquePesado", true);
            atacou = true;
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
        if (col.gameObject.tag.Equals("Caracol"))
        {
            Pisca = true;
            GameObject.FindGameObjectWithTag("Life").GetComponent<LivePlayer>().LifePlayer();
            GameObject.FindGameObjectWithTag("Life").GetComponent<LivePlayer>().life -= 1;
            lifePlayer -= 2;
            StartCoroutine(DamagePlayer());
            StartCoroutine(DamageBlink());
        }
    }
     void OnTriggerEnter2D(Collider2D Collo)
    {
        if (Collo.gameObject.name == "AguaAtras")
        {
            aguaAtras.GetComponent<Tilemap>().color = new Color(255, 255, 255, 0.7137255f);  
        }
        if (Collo.gameObject.tag.Equals("Tinta"))
        {
            Pisca = true;
            GameObject.FindGameObjectWithTag("Life").GetComponent<LivePlayer>().LifePlayer();
            GameObject.FindGameObjectWithTag("Life").GetComponent<LivePlayer>().life -= 1;
            lifePlayer -= 1;
            StartCoroutine(DamagePlayer());
            StartCoroutine(DamageBlink());
        }

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
            andar = true;
           

        }
    }
   public IEnumerator DamagePlayer()
    {
        while (Pisca == true)
        {
            yield return new WaitForSeconds(0.1f);
            Player.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
            yield return new WaitForSeconds(0.1f);
            Player.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
        }
    }
    IEnumerator DamageBlink()
    {
        yield return new WaitForSeconds(1);
        Pisca = false;
        StopCoroutine(DamagePlayer());
        StopCoroutine(DamageBlink());
    }
}
