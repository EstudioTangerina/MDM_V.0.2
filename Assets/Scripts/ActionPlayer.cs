using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionPlayer : MonoBehaviour
{
    private float Speed;
    public float jumpSpeed = 3.5f;
    private bool isGrounded = true;


    private Rigidbody2D RB;

    private Animator anim;


    private int timeJump;

    // Use this for initialization
    void Start()
    {

        RB = GetComponent<Rigidbody2D>();
        Speed = 2.5f;
        timeJump = 3;
        anim = GetComponent<Animator>();


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Ataque();
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
        if (Input.GetKey(KeyCode.Z))
        {
            anim.SetBool("AtaqueLeve", true);
        }
        else
        {
            anim.SetBool("AtaqueLeve", false);
        }

        if (Input.GetKey(KeyCode.X))
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

}
