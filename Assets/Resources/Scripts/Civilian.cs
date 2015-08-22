using UnityEngine;
using System.Collections;

public class Civilian : MonoBehaviour 
{
	GameObject player;

	bool alive = true;
	SpriteRenderer spRender;
	int skinIdx;
	
	public bool canMove = true;
	public int pointValue = 5;
	bool runRight = true;
	float hopFreq = 1;
	float hopTimer = 0;
	float distance;

	void Start () 
	{
		player = GameObject.FindGameObjectWithTag("Player");
		
		skinIdx = Random.Range (1, 4);
		spRender = this.GetComponent<SpriteRenderer>();
		spRender.sprite = Resources.Load<Sprite>("Art/Person" + skinIdx);
		
		hopFreq = (float)Random.Range (1, 10) / 5f;
	}
	
	void FixedUpdate () 
	{
		distance = Vector2.Distance (transform.position, player.transform.position);
		if (canMove && distance < 30)
			{
				hopTimer += Time.deltaTime;
				
				runRight = (transform.position.x - player.transform.position.x > 0);
				if (hopTimer > hopFreq)
				{
					hopTimer = 0;
					if (runRight)
						rigidbody2D.AddForce(new Vector2(1, 1));
					else
						rigidbody2D.AddForce(new Vector2(-1, 1));
				}
			}
	}
	
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Player")
		{
			rigidbody2D.fixedAngle = false;
			if (alive)
			{
				Score.score += pointValue;
			}
			alive = false;
			canMove = false;
		}
	}
}
