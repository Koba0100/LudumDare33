﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Upgrades : MonoBehaviour {

	public static bool rocketUnlocked = false;
	public static bool deathRayUnlocked = false;
	public static bool powerUnlocked = false;
	public static bool deathUnlocked = false;
	static GameObject rocketPrefab;
	static GameObject deathRayPrefab;
	static GameObject lrSatanPrefab;

	public static GameObject locksBase;
	public static Image[] locks;
	
	public AudioSource BGM;
	
	public Text HPText;
	public Text HPTextShad;
	public Text HPNumber;
	public Text HPNumberShad;
	
	public Canvas endSlate;
	
	public Canvas cDownCanvas;
	public Text cDown;
	public Text cDownShad;
	float cDownTimer = 3f;
	
	bool satanSpawned = false;

	// Use this for initialization
	void Start () 
	{
		rocketUnlocked = false;
		deathRayUnlocked = false;
		powerUnlocked = false;
		deathUnlocked = false;
		rocketPrefab = Resources.Load<GameObject>("Prefabs/Rocket");
		deathRayPrefab = Resources.Load<GameObject>("Prefabs/DeathRay");
		lrSatanPrefab = Resources.Load<GameObject>("Prefabs/LowResSatan");
		locksBase = GameObject.FindGameObjectWithTag("Locks");
		locks = locksBase.GetComponentsInChildren<Image>();
		
		BGM = Camera.main.GetComponent<AudioSource>();
		
		HPText.color = new Color (1, 1, 1, 0);
		HPTextShad.color = new Color (0, 0, 0, 0);
		HPNumber.color = new Color (1, 1, 1, 0);
		HPNumberShad.color = new Color (0, 0, 0, 0);
		
		endSlate.enabled = false;
		cDownCanvas.enabled = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		//if (Input.GetKeyDown(KeyCode.R))
			//UnlockRocket();
		if (powerUnlocked && Camera.main.orthographicSize < 20)
		{
			Camera.main.orthographicSize += 0.2f;
		}
		if (powerUnlocked && BGM.volume > 0.1f)
		{
			BGM.volume -= 0.02f;
		}
		
		if (deathUnlocked)
		{
			HPText.color = new Color (1, 1, 1, 1);
			HPTextShad.color = new Color (0, 0, 0, 1);
			HPNumber.color = new Color (1, 1, 1, 1);
			HPNumberShad.color = new Color (0, 0, 0, 1);
			
			HPNumber.text = LRSatan.bossHP.ToString();
			HPNumberShad.text = LRSatan.bossHP.ToString();
			
			if (LRSatan.bossHP <= 0)
			{
				endSlate.enabled = true;
			}
			
			cDownCanvas.enabled = true;
			cDownTimer -= Time.deltaTime;
			cDown.text = (cDownTimer + 1).ToString();
			cDownShad.text = (cDownTimer + 1).ToString();
			if (cDownTimer <= 0f && !satanSpawned)
			{
				satanSpawned = true;
				Instantiate (lrSatanPrefab);
				Camera.main.GetComponent<AudioSource>().pitch = 1.19f;				
			}
			if (cDownTimer <= 0f)
			{
				cDownCanvas.enabled = false;
			}
		}
	}
	
	
	public static void UnlockRocket ()
	{
		if (!rocketUnlocked)
		{
			rocketUnlocked = true;
			Instantiate (rocketPrefab);
			Debug.Log("Rocket Unlocked");
			locks[0].color = (new Color(0, 0, 0, 0));
		}
	}
	
	public static void UnlockDeathRay ()
	{
		if (!deathRayUnlocked)
		{
			deathRayUnlocked = true;
			Instantiate (deathRayPrefab);
			Debug.Log("Death Ray Unlocked");
			locks[1].color = (new Color(0, 0, 0, 0));
		}
	}
	
	public static void UnlockRocketPower ()
	{
		if (!powerUnlocked)
		{
			powerUnlocked = true;
			//Instantiate (rocketPrefab);
			locks[2].color = (new Color(0, 0, 0, 0));
		}
	}
	
	public static void UnlockDeath ()
	{
		if (!deathUnlocked)
		{
			deathUnlocked = true;
			AudioSource.PlayClipAtPoint(Resources.Load<AudioClip>("Sounds/Upgrade"), GameObject.FindGameObjectWithTag("Player").transform.position);
			locks[3].color = (new Color(0, 0, 0, 0));
		}
	}
}
