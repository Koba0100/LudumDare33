using UnityEngine;
using System.Collections;

public class SatExtras : MonoBehaviour {

	public Sprite Green;
	public Sprite Red;
	public Civilian stdAttributes;
	public SpriteRenderer spRender;


	void Start () 
	{
		stdAttributes = this.GetComponent<Civilian>();
		spRender = this.GetComponent<SpriteRenderer>();
		Green = Resources.Load<Sprite>("Art/SatGreen");
		Red =  Resources.Load<Sprite>("Art/SatRed");
	}
	

	void FixedUpdate () 
	{
		if (stdAttributes.alive)
		{
			spRender.sprite = Green;
		}
		else
		{
			spRender.sprite = Red;
		}
		
		if (transform.position.y > 210)
		{
			rigidbody2D.gravityScale = 0;
		}
		else
		{
			rigidbody2D.gravityScale = 1;
		}
	}
}
