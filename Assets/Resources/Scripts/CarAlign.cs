using UnityEngine;
using System.Collections;

public class CarAlign : MonoBehaviour 
{
	public Transform ferrisWheel;
	public Quaternion fWR;
	
	void FixedUpdate () 
	{
		fWR = ferrisWheel.rotation;
		transform.localRotation = new Quaternion(1 * fWR.x, -1 * fWR.y, 1 * fWR.z, -1 * fWR.w);
	}
}
