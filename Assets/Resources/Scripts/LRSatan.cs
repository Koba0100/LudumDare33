using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LRSatan : MonoBehaviour {

	bool fightStarted = false;
	GameObject player;
	GameObject restart;

	public Text bossHPText;
	public Text bossHPTextShad;
	
	public static int bossHP = 1000;
	
	
	// INITIAL VARS //
	float initTimer = 0f;
	bool shortPause = true;
	float pauseEnd;
	
	// STANDARD VARS //
	float actionTimer = 0f;
	

	void Start () 
	{
		bossHP = 1000;
		player = GameObject.FindGameObjectWithTag("Player");
		restart = GameObject.FindGameObjectWithTag("Restart");
		player.transform.position = new Vector2 (313f, 25f);
		player.rigidbody2D.velocity = new Vector2 (0f, 0f);
		player.rigidbody2D.angularVelocity = 0f;
		Camera.main.orthographicSize = 30f;
		

	}
	
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Laser")
		{
			Destroy (other.gameObject);
			bossHP--;
		}
	}

	void FixedUpdate () 
	{
		if (fightStarted)
			StandardBehavior();
		else
			InitialBehavior();
			
			
		if (bossHP <= 0)
		{
			Destroy (this.gameObject);
		}
	}
	
	void InitialBehavior ()
	{
		initTimer += Time.deltaTime;
		
		//if (initTimer > 0.2f && shortPause)
		if (initTimer < 1f)
		{
		//	shortPause = false;
		//	Time.timeScale = 0;
		//	pauseEnd = Time.realtimeSinceStartup + 1;
		//	while (Time.realtimeSinceStartup < pauseEnd)
		//	{
		//		// Nothing
		//	}
		//	Time.timeScale = 1;
			DeathRayUpgrade.canFire = false;
		}
		else
			DeathRayUpgrade.canFire = true;
		
		if (initTimer > 2.5f && initTimer < 2.6f)
		{
			rigidbody2D.AddForce (new Vector2(0f, 250f));
		}
		if (initTimer > 3.5f)
		{
			fightStarted = true;
		}
	}
	
	void StandardBehavior ()
	{
		actionTimer += Time.deltaTime;
		if (actionTimer > 3f)
		{
			actionTimer = 0f;
			rigidbody2D.AddForce (new Vector2(0f, 350f));
		}
			
		if (restart.transform.position.x > transform.position.x)
			rigidbody2D.AddForce (new Vector2(7f, 20f));
		else
			rigidbody2D.AddForce (new Vector2(-7f, 20f));
			
		if (restart.transform.position.y > transform.position.y)
			rigidbody2D.AddForce (new Vector2(0f, 40f));
			
		// Limits
		if (rigidbody2D.velocity.x > 20f)
			rigidbody2D.velocity = new Vector2 (20f, rigidbody2D.velocity.y);
		if (rigidbody2D.velocity.x < -20f)
			rigidbody2D.velocity = new Vector2 (-20f, rigidbody2D.velocity.y);			
		if (rigidbody2D.velocity.y > 15f)
			rigidbody2D.velocity = new Vector2 (rigidbody2D.velocity.x, 15f);
	}
}
