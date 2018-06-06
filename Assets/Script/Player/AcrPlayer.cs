using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcrPlayer : MonoBehaviour {

    public GameObject other;

    private GameObject other1;

    public int life;

    public LayerMask notToHit;

    public bool count;

    public bool podevoltar;

    private int rotationarm;

    private float speed;
    private float horizontalspeed;

    private Rigidbody2D rb;

    private bool toright;
    private bool canjump;
    public bool cantshot;

    private Vector2 jumpheight;

    private Vector2 firePointPosisiton;

    private Transform arm;
    Transform firePoint;

    private GameObject spawnBullet;

    [SerializeField]
    private GameObject bullet;

    public GameObject inst;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        foreach (Transform child in transform)
        {
            foreach (Transform grandson in child)
            {
                firePoint = grandson;
            }
        }

        spawnBullet = GameObject.FindGameObjectWithTag("Shoot");

        life = 5;

        speed = 9f;

        toright = true;

        podevoltar = false;

        cantshot = false;

        jumpheight = Vector2.up * 12f;

        arm = transform.Find("Arm");

        count = true;
    }

    void Update()
    {
        RotationArm();
        Atack();
    }
        
    void FixedUpdate()
    {
        Walk();

        if (!canjump)
        {
            Jump();
        }

        if (podevoltar == true)
        {
            VoltaArpao();
        }
    }

    void RotationArm()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - arm.transform.position;
        difference.Normalize();

        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        if (transform.localScale.x < 0)
        {
            rotZ -= 180;
            if (inst)
            {
                if (inst.transform.localScale.x > 0)
                {
                    inst.GetComponent<Transform>().localScale *= -1;
                } 
            }
        }
        else
        {
            if (inst)
            {
                inst.GetComponent<Transform>().localScale *= 1;
            }    
        }
        arm.transform.rotation = Quaternion.Euler(0f, 0f, rotZ + rotationarm);    
    }

    void Walk()
    {
        horizontalspeed = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(horizontalspeed * speed, rb.velocity.y);

        FaceMouse();
    }

    void Jump()
    {
        if (!canjump)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space))
            {
                GetComponent<Rigidbody2D>().AddForce(jumpheight, ForceMode2D.Impulse);
                canjump = true;
            }
        }
    }

    void VoltaArpao()
    {
        Vector2 Posivolta = new Vector2(transform.position.x, transform.position.y + 0.75f);

        Vector2 meuvetorbacana = (Vector2)inst.transform.position - Posivolta;
        inst.GetComponent<Rigidbody2D>().velocity -= meuvetorbacana;
    }

    void FaceMouse()
    {
        var mp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var dif = mp - transform.position;

        if (dif.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    void Atack()
    {
        if (count == true && cantshot == false)
        {
            if (Input.GetMouseButtonDown(0))
            { 
                Shoot();
                cantshot = true;
            }
        }
        if(count == false && cantshot == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                podevoltar = true;
                cantshot = false;
                inst.GetComponent<Collider2D>().isTrigger = true;
            }    
        }
    }

    void Shoot()
    {
        Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        firePointPosisiton = new Vector2(firePoint.position.x, firePoint.position.y);
        RaycastHit2D hit = Physics2D.Raycast(firePointPosisiton, mousePosition - firePointPosisiton, 100, notToHit);
        InsBullet();
    }

    void InsBullet()
    {
        inst = Instantiate(bullet, firePoint.position, firePoint.rotation);
        inst.GetComponent<Collider2D>().isTrigger = false;
    }


    public IEnumerator Knockback(float KnockDur, float KnockPwr, Vector3 KnockbackDir)
    {
        float timer  = 0;

        while(KnockDur > timer)
        {
            timer += Time.deltaTime;

            if(transform.position.x < other1.transform.position.x)
                rb.AddForce(new Vector3(KnockbackDir.x * -100, KnockbackDir.y * KnockPwr, transform.position.z));
            if(transform.position.x > other1.transform.position.x)
                rb.AddForce(new Vector3(KnockbackDir.x * 100, KnockbackDir.y * KnockPwr, transform.position.z));
        }

        yield return 0;
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag.Equals("Floor"))
        {
            canjump = false;
        }
        if (coll.gameObject.tag.Equals("Mob"))
        {
            other1 = coll.gameObject;
        }
    }
}
