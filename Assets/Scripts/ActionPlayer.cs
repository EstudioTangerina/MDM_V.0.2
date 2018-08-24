using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine;

public class ActionPlayer : MonoBehaviour
{
    private float speed;
    public float jumpSpeed = 5.5f;

    private bool isGrounded = true;
    private bool andou = false;
    public bool passou = true;

    public GameObject aguaAtras;

    private Rigidbody2D rb;

    private Animator anim;

    private int timeJump;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = 3.5f;
        timeJump = 3;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Ataque();
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

    #region EndAnim

    public void EndAtckPesado()
    {
        anim.SetBool("AtaquePesado", false);
    }
    #endregion

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
            aguaAtras.GetComponent<Tilemap>().color = new Color(255, 255, 255, 0.7137255f);  
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
         if (collision.gameObject.name == "AguaAtras")
        {
            aguaAtras.GetComponent<Tilemap>().color = new Color(255, 255, 255, 1f);
        }
    }

}
