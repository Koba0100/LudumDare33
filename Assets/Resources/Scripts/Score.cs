using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	public static int score = 0;
	public Text scoreBox;
	public Text scoreBoxShadow;

	// Use this for initialization
	void Start () {
		score = 0;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		scoreBox.text = score.ToString();
		scoreBoxShadow.text = score.ToString();
	}
}
