using UnityEngine;
using System.Collections;

public class LaserScript : MonoBehaviour {
	
	public DeathRayUpgrade dRay;
	GameObject player;
	Vector2 speed;
	float lifetimer = 0f;
	
	AudioClip laserSound;
	
	public LayerMask whatIsGround;
	bool collide = false;

	// Use this for initialization
	void Start () 
	{
		player = GameObject.FindGameObjectWithTag("Player");
		dRay = GameObject.FindGameObjectWithTag("DeathRay").GetComponent<DeathRayUpgrade>();
		speed = new Vector2(50 * Mathf.Cos (dRay.angle * Mathf.Deg2Rad) + player.rigidbody2D.velocity.x , 50 * Mathf.Sin (dRay.angle * Mathf.Deg2Rad) + player.rigidbody2D.velocity.y);
		laserSound = Resources.Load<AudioClip>("Sounds/Laser");
		AudioSource.PlayClipAtPoint(laserSound, player.transform.position);
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		rigidbody2D.velocity = speed;
		lifetimer += Time.deltaTime;
		collide = Physics2D.OverlapCircle(transform.position, 0.7f, whatIsGround);
		if (lifetimer > 2f || collide)
			Destroy (this.gameObject);
	}
}
