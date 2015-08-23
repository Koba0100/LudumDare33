using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Upgrades : MonoBehaviour {

	public static bool rocketUnlocked = false;
	public static bool deathRayUnlocked = false;
	public static bool powerUnlocked = false;
	public static bool deathUnlocked = false;
	static GameObject rocketPrefab;
	static GameObject deathRayPrefab;

	public static GameObject locksBase;
	public static Image[] locks;
	
	public AudioSource BGM;

	// Use this for initialization
	void Start () 
	{
		rocketUnlocked = false;
		deathRayUnlocked = false;
		powerUnlocked = false;
		deathUnlocked = false;
		rocketPrefab = Resources.Load<GameObject>("Prefabs/Rocket");
		deathRayPrefab = Resources.Load<GameObject>("Prefabs/DeathRay");
		locksBase = GameObject.FindGameObjectWithTag("Locks");
		locks = locksBase.GetComponentsInChildren<Image>();
		
		BGM = Camera.main.GetComponent<AudioSource>();
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
