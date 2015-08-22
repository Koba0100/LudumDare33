using UnityEngine;
using System.Collections;

public class DeathRayUpgrade : MonoBehaviour 
{
	public Transform tutorial;
	public Transform laserOrigin;
	public GameObject laserPrefab;

	Vector3 pos;
	Vector3 dir;
	public float angle;

	// Use this for initialization
	void Start () 
	{
		laserPrefab = Resources.Load<GameObject>("Prefabs/Laser");
		tutorial.parent = null;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		// Rotation
		pos = Camera.main.WorldToScreenPoint(transform.position);
		dir = Input.mousePosition - pos;
		angle = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);
		
		
		// Fire
		if (Input.GetKey(KeyCode.Mouse1))
		{ 
			tutorial.localScale = new Vector3 (0, 0, 0);
			Instantiate (laserPrefab, laserOrigin.position, transform.rotation);
		}
	}
}
