using UnityEngine;
using System.Collections;

public class Platform : MonoBehaviour 
{

	GameObject player;
	public bool plat = false;

	void Start () 
	{
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	void OnTriggerStay2D(Collider2D other)
	{
		if (other.tag == "Player") 
		{
			if ((player.transform.position.y - 8) < this.transform.position.y) { // This is for falling through / jumping up onto the platform
				plat = true;
			}	
			if (plat) {
				Physics2D.IgnoreCollision (collider2D, other, true);
			}
		}
	}
	void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "Player") 
		{
			Physics2D.IgnoreCollision (collider2D, other, false);
			plat = false;
		}
	}

}
