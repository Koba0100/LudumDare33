using UnityEngine;
using System.Collections;

public class SatanRestart : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
		rigidbody2D.gravityScale = 0;
		rigidbody2D.velocity = new Vector2 (0f, 0f);
		transform.parent = null;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
	
	}
	
	void OnTriggerEnter2D (Collider2D other)
	{
		if (rigidbody2D.gravityScale == 0)
			rigidbody2D.AddForce(new Vector2(-40f, 40f));
		rigidbody2D.gravityScale = 0.8f;
		if (other.tag == "Satan")
		{
			Application.LoadLevel ("Scene01");
		}
	}
}
