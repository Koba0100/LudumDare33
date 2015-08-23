using UnityEngine;
using System.Collections;

public class UnlockRocket : MonoBehaviour 
{
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Player")
		{
			Upgrades.UnlockRocket();
			Destroy(this.gameObject);
			AudioSource.PlayClipAtPoint(Resources.Load<AudioClip>("Sounds/Upgrade"), GameObject.FindGameObjectWithTag("Player").transform.position);
		}
	}
}
