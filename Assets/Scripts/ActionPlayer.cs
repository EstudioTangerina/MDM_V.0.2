using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine;

public class ActionPlayer : MonoBehaviour
{
    private float Speed;
    public float jumpSpeed;
    private bool isGrounded = true;

    private bool Andou = false;

    public GameObject AguaAtras;
    public bool Passou = true;

    private Rigidbody2D RB;

    private Animator anim;


    private int timeJump;

    // Use this for initialization
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        Speed = 4f;
        jumpSpeed = 7f;
        timeJump = 3;
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        Ataque();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        moviment();

        if (isGrounded == false) anim.SetBool("Pulando", true);
        else anim.SetBool("Pulando", false);
        anim.SetFloat("Blend", RB.velocity.y);
    }

    void moviment()
    {
        anim.SetFloat("Speed", Mathf.Abs(Input.GetAxisRaw("Horizontal")));

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * Speed * Time.deltaTime;
            transform.eulerAngles = new Vector2(0, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * Speed * Time.deltaTime;
            transform.eulerAngles = new Vector2(0, 180);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && timeJump < 2 || Input.GetKeyDown(KeyCode.W) && timeJump < 2)
        {
            RB.velocity = new Vector2(RB.velocity.x, jumpSpeed);
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
        else
        {
            anim.SetBool("AtaquePesado", false);
        }
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Chao")
        {
            timeJump = 0;
            isGrounded = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.name == "AguaAtras")
        {
            AguaAtras.GetComponent<Tilemap>().color = new Color(255, 255, 255, 0.7137255f);  
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
         if (collision.gameObject.name == "AguaAtras")
        {
            AguaAtras.GetComponent<Tilemap>().color = new Color(255, 255, 255, 1f);
        }
    }

}
