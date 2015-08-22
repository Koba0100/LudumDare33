using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{

	public float rotForce = 1f;


	bool attached = true;

	void Start () 
	{
		rigidbody2D.gravityScale = 0;
		rigidbody2D.AddTorque(0.5f);
	}
	
	void FixedUpdate () 
	{

		// BASIC MOVEMENT.		
		if (Input.GetKey(KeyCode.A))
		{
			rigidbody2D.AddTorque(rotForce);
		}
		if (Input.GetKey(KeyCode.D))
		{
			rigidbody2D.AddTorque(-rotForce);
		}
		
		// BREAK OFF.
		if ((rigidbody2D.angularVelocity > 1000 || rigidbody2D.angularVelocity < -1000) && attached)
		{
			BreakOff();
		}
	}
	
	void BreakOff()
	{
		rigidbody2D.gravityScale = 1;
		rigidbody2D.AddForce(new Vector2(rigidbody2D.angularVelocity / -20, 50));
		attached = false;
	}
	
	void Update ()
	{
	
	}
}
