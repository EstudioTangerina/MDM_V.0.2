using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caracol : MonoBehaviour
{
	public int lifeCaracol;

	public LayerMask maskCaracol;

	private Rigidbody2D rbCaracol;

	private Transform transformCaracol;

	private ActionPlayer player;

    bool pisca = false;

	float speedCaracol;
	float widthCaracol, heightCaracol;


	private void Start()
	{
		speedCaracol = 2f;

		lifeCaracol = 10;

		player = GameObject.FindGameObjectWithTag("Player").GetComponent<ActionPlayer>();

		transformCaracol = this.transform;
		rbCaracol = GetComponent<Rigidbody2D>();
		SpriteRenderer renderCaracol = GetComponent<SpriteRenderer>();
		widthCaracol = renderCaracol.bounds.extents.x;
		heightCaracol = renderCaracol.bounds.extents.y;
	}

	private void Update()
	{
		CaracolDead();
	}

	private void FixedUpdate()
	{
		
		Vector2 lineConstPost = transformCaracol.position.toVector2() - transformCaracol.right.toVector2() * widthCaracol + Vector2.down * heightCaracol;
		Debug.DrawLine(lineConstPost, lineConstPost + Vector2.up);
		bool isGrounded = Physics2D.Linecast(lineConstPost, lineConstPost + Vector2.down, maskCaracol);
		Debug.DrawLine(lineConstPost, lineConstPost - transformCaracol.right.toVector2());
		bool isBlocked = Physics2D.Linecast(lineConstPost, lineConstPost - transformCaracol.right.toVector2() * 0.01f, maskCaracol);

		if (!isGrounded|| isBlocked)
		{
			Vector3 currRot = transformCaracol.eulerAngles;
			currRot.y += 180;
			transformCaracol.eulerAngles = currRot;
		}

		///
		Vector2 velCaracol = rbCaracol.velocity;
		velCaracol.x = -transformCaracol.right.x * speedCaracol;
		rbCaracol.velocity = velCaracol;
	}

	void CaracolDead() {

		if(lifeCaracol <= 0)
		{
			Destroy(this.gameObject);
		}

	}

    IEnumerator DamageMob()
    {
        if (pisca == true)
        {
            yield return new WaitForSeconds(0.1f);
            GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
            yield return new WaitForSeconds(0.1f);
            GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
        }
    }


    private void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag.Equals("Player"))
		{
			player.lifePlayer -= 1;
		}
	}

	private void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.tag.Equals("Anchor") && player.atacou == true)
		{
			lifeCaracol -= 1;
            pisca = true;
			print(lifeCaracol);
		}
	}
}
