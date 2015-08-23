using UnityEngine;
using System.Collections;

public class RocketUpgrade : MonoBehaviour {

	GameObject player;
	public Transform tutorial;
	//SpriteRenderer spRender;
	//Sprite normal;
	//Sprite boost;
	public ParticleSystem booster;
	public ParticleSystem booster2;
	
	Vector3 pos;
	Vector3 dir;
	public float angle;
	
	AudioClip rocketSound;

	// Use this for initialization
	void Start () 
	{
		player = GameObject.FindGameObjectWithTag("Player");
		//spRender = this.GetComponent<SpriteRenderer>();
		
		//normal = Resources.Load<Sprite>("Art/Rocket");
		//boost = Resources.Load<Sprite>("Art/RocketBoost");
		tutorial.parent = null;
		
		rocketSound = Resources.Load<AudioClip>("Sounds/Rocket");
		booster.enableEmission = false;
		booster2.enableEmission = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		// Rotation
		pos = Camera.main.WorldToScreenPoint(transform.position);
		dir = Input.mousePosition - pos;
		angle = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);
		
		// Booster
		if (Input.GetKey (KeyCode.Mouse0))
		{
			//spRender.sprite = boost;
			player.rigidbody2D.AddForce (new Vector2(10 * Mathf.Cos (angle * Mathf.Deg2Rad), 20 * Mathf.Sin (angle * Mathf.Deg2Rad))); 
			if (Upgrades.powerUnlocked)
			{
				player.rigidbody2D.AddForce (new Vector2(10 * Mathf.Cos (angle * Mathf.Deg2Rad), 20 * Mathf.Sin (angle * Mathf.Deg2Rad))); 
				booster2.enableEmission = true;
			}
			tutorial.localScale = new Vector3 (0, 0, 0);
			AudioSource.PlayClipAtPoint(rocketSound, player.transform.position);
			booster.enableEmission = true;
		}
		else
		{
			//spRender.sprite = normal;
			booster.enableEmission = false;
			booster2.enableEmission = false;
		}
	}
}
