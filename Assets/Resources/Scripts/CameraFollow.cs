using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour 
{

	public Transform toFollow;
	
	public float xOffset = 0;
	public float yOffset = 0;
	public float zOffset = -10;

	void  Update () 
	{
		transform.position = new Vector3(toFollow.position.x + xOffset, toFollow.position.y + yOffset, zOffset);
	}
}
