using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class Scorer : MonoBehaviour
{
    public static int score;
	public static bool onceU = true;
	public Graphic graph;

    Text text;

    void Awake ()
    {
        text = GetComponent <Text> ();
		score = PlayerPrefs.GetInt("pScore");
		text.text = score + " feet";
		graph = GetComponent<Graphic>();
    }

    void FixedUpdate ()
    {
		if(PopBalloon.gameOn == true && Time.timeScale == 1)
		{
			score = Movement.scoreM;
	  		text.text = score + " feet";
			PlayerPrefs.SetInt("pScore", score);
			//Achievements Android
			/*if(score == 500)
			{
				// unlock achievement (achievement ID for Empire State Building)
				Social.ReportProgress("CgkIgtbIw5MREAIQAA", 100.0f, (bool success) => {
				// handle success or failure
				});	
			}
			else if(score == 1000)
			{
				// unlock achievement (achievement ID for Burj Khalifa)
				Social.ReportProgress("CgkIgtbIw5MREAIQAQ", 100.0f, (bool success) => {
				// handle success or failure
				});	
			}
			else if(score == 1500)
			{
				// unlock achievement (achievement ID for Mount Everest)
				Social.ReportProgress("CgkIgtbIw5MREAIQAg", 100.0f, (bool success) => {
				// handle success or failure
				});
			}*/
			if(score == 2000) //else if for android
			{
				// unlock achievement (achievement ID for Space)
				//Social.ReportProgress("CgkIgtbIw5MREAIQAw", 100.0f, (bool success) => {
				// handle success or failure
				//});
				graph.color = Color.white; //Needed to change score color
			}/*
			else if(score == 5280)
			{
				// unlock achievement (achievement ID for Mile High Club)
				Social.ReportProgress("CgkIgtbIw5MREAIQBA", 100.0f, (bool success) => {
				// handle success or failure
				});	
			}*/
			else
			{
				;
			}
		}
		else
		{
			;
		}
	}
}