﻿using UnityEngine;
using System.Collections;

public class UnlockPower : MonoBehaviour 
{
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Player")
		{
			Upgrades.UnlockRocketPower();
			Destroy(this.gameObject);
			AudioSource.PlayClipAtPoint(Resources.Load<AudioClip>("Sounds/Upgrade"), GameObject.FindGameObjectWithTag("Player").transform.position);
		}
	}
}
