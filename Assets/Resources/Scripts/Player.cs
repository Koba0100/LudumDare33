using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
	public Transform groundCheck;
	public LayerMask whatIsGround;

	public float rotForce = 1f;


	bool attached = true;
	bool grounded = true;

	void Start () 
	{
		rigidbody2D.gravityScale = 0;
		rigidbody2D.AddTorque(0.5f);
	}
	
	void Update () 
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
		
		// JUMP.
		grounded = Physics2D.OverlapCircle(groundCheck.position, 0.001f, whatIsGround);
		if (Input.GetKeyDown(KeyCode.Space) && grounded)
		{
			rigidbody2D.AddForce(new Vector2(0, 75));
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
}
