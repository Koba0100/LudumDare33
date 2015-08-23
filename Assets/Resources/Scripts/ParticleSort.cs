using UnityEngine;
using System.Collections;

public class ParticleSort : MonoBehaviour 
{	
	public int orderInLayer = 100;
	
	void Start ()
	{
		particleSystem.renderer.sortingOrder = orderInLayer;
	}
}
