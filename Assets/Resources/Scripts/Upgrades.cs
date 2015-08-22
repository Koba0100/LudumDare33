using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Upgrades : MonoBehaviour {

	public static bool rocketUnlocked = false;
	static GameObject rocketPrefab;

	public static GameObject locksBase;
	public static Image[] locks;

	// Use this for initialization
	void Start () 
	{
		rocketPrefab = Resources.Load<GameObject>("Prefabs/Rocket");
		locksBase = GameObject.FindGameObjectWithTag("Locks");
		locks = locksBase.GetComponentsInChildren<Image>();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		//if (Input.GetKeyDown(KeyCode.R))
			//UnlockRocket();
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
}
