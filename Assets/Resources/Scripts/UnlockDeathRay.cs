using UnityEngine;
using System.Collections;

public class UnlockDeathRay : MonoBehaviour 
{
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Player")
		{
			Upgrades.UnlockDeathRay();
			Destroy(this.gameObject);
		}
	}
}
