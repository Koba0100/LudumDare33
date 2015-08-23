using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeAttack : MonoBehaviour 
{

	GameObject player;
	Player playerScript;
	
	bool timeAttackEnabled = false;
	
	//public Text timeText;
	//public Text timeTextShad;
	public Text timer;
	public Text timerShad;
	
	static int hiScoreVal = 0;
	public Text hiScoreNum;
	public Text hiScoreNumShad;
	
	public float timeVal = 0;

	// Use this for initialization
	void Start () 
	{
		player = GameObject.FindGameObjectWithTag("Player");
		playerScript = player.GetComponent<Player>();
		timer.text = "XX";
		timerShad.text = "XX";
		hiScoreNum.text = hiScoreVal.ToString ();
		hiScoreNumShad.text = hiScoreVal.ToString ();
	}
	void Update()
	{
		if (Input.GetKeyDown (KeyCode.T) && playerScript.attached)
		{
			timeAttackEnabled = true;
			timeVal = 30;
			timer.text = timeVal.ToString();
			timerShad.text = timeVal.ToString();
			playerScript.BreakOff();
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if (timeAttackEnabled)
		{
			timeVal -= Time.deltaTime;
			timer.text = timeVal.ToString();
			timerShad.text = timeVal.ToString();
			if (timeVal < 0.02f)
			{
				//Time.timeScale = 0f;
				//timeVal = 0;
				//timer.text = 0;
				//timerShad.text = 0;
				if (Score.score > hiScoreVal)
				{
					hiScoreVal = Score.score;
				}
				Application.LoadLevel ("Scene01");
			}
			else
			{
				//Time.timeScale = 1f;
			}
		}
		else
		{
			//Time.timeScale = 1f;
		}
	}
}
