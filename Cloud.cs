using UnityEngine;
using System.Collections;

public class Cloud : MonoBehaviour {

	public float cloudH;
	public float cloudV;
	public float countH;

	void Update () {
	
		//Pause
		if(PopBalloon.gameOn == false)
		{
			highScore.hScore = PlayerPrefs.GetInt("Score"); //Save Highscore
			if(Input.touchCount > 0) //Wait till player touches
			{
				Scorer.score = 0;
				PopBalloon.gameOn = true;
				Time.timeScale = 1;
			}
			float cloudMoveH = cloudH; //Horizontal Movement
			if (cloudH >= 5.0f)
			{
				countH = -0.01f;
				cloudH = cloudH + (-0.1f);
			}
			else if (cloudH <= -5.0f)
			{
				countH = 0.01f;
				cloudH = cloudH + 0.1f;
			}
			else
			{
				cloudH = cloudH + (countH);
			}
			transform.position = new Vector3(cloudMoveH,transform.position.y,-0.01f);
		}
	}
	
	void FixedUpdate () { //make movement velocity **********************
		float cloudMoveH = cloudH; //Horizontal Movement
		float cloudMoveV = cloudV; //Vertical Movement
		
		if(Scorer.score < 2000) //Not Space
		{	
			//Cloud Movement
			
			if(cloudV <= -7.0f)
			{
				cloudV = 7.0f;
			}
			else if (cloudH >= 5.0f)
			{
				countH = -0.01f;
				cloudH = cloudH + (-0.1f);
			}
			else if (cloudH <= -5.0f)
			{
				countH = 0.01f;
				cloudH = cloudH + 0.1f;
			}
			else
			{
				cloudH = cloudH + (countH);
				cloudV = cloudV - 0.05f;
			}
		}	
		
		else if(Scorer.score >= 2000) //Space
		{
			if(cloudV <= -8.0f)
			{
				;
			}
			else
			{
				cloudV = cloudV - 0.05f;
			}
		}
		else
		{
			;
		}
		
		transform.position = new Vector3(cloudMoveH,cloudMoveV,-0.01f);
	}
}