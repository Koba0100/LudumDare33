using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ControlsFade : MonoBehaviour {

	GameObject player;
	Vector3 initialPos;
	
	public Text controlsText;
	public Text controlsTextShadow;
	public Image controlsImage;
	
	public Text controlsRestart;
	public Text controlsRestartShadow;
	public Image rkey;
	
	public Text TAttack;
	public Text TAttackShad;
	public Image tkey;
	
	public Text hiScore;
	public Text hiScoreShad;
	public Text hiScoreNum;
	public Text hiScoreNumShad;
	
	void Start ()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		initialPos = player.transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if (initialPos != player.transform.position)
		{
			controlsText.text = "";
			controlsTextShadow.text = "";
			controlsImage.color = new Color(0, 0, 0, 0);
			
			controlsRestart.text = "";
			controlsRestartShadow.text = "";
			rkey.color = new Color(0, 0, 0, 0);
			
			TAttack.text = "";
			TAttackShad.text = "";
			tkey.color = new Color(0, 0, 0, 0);
			
			hiScore.color = new Color(0, 0, 0, 0);
			hiScoreShad.color = new Color(0, 0, 0, 0);
			hiScoreNum.color = new Color(0, 0, 0, 0);
			hiScoreNumShad.color = new Color(0, 0, 0, 0);
			
		}
	}
}
