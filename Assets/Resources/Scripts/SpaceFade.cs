using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpaceFade : MonoBehaviour {

	GameObject player;
	Image space;

	// Use this for initialization
	void Start () 
	{
		player = GameObject.FindGameObjectWithTag("Player");
		space = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		space.color = new Color(1f, 1f, 1f, (player.transform.position.y - 200) / 50);
	}
}
