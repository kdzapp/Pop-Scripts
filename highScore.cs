using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class highScore : MonoBehaviour {

	public static int hScore = 0;
	public Graphic graph;

	Text texth;
	
	void Awake ()
	{
		texth = GetComponent <Text> ();
		hScore = PlayerPrefs.GetInt("Score");
		graph = GetComponent<Graphic>();
	}

	void Update () 
	{
		if(Scorer.score >= 2000 && Scorer.score < 2010)
		{
			whiteC();
		}
		else if(Scorer.score > hScore)
		{
			hScore = Scorer.score;
			PlayerPrefs.SetInt("Score", hScore);
			Social.ReportScore (hScore, "grp.feetLB" , success => {
				Debug.Log(success ? "Reported score successfully" : "Failed to report score");
			});
			//Social.ReportScore(hScore, "CgkIgtbIw5MREAIQBQ", (bool success) => {
			// handle success or failure
			//}); //Android Score
		}
		else
		{
			;
		}
		texth.text = hScore + " feet";
	}
	
	void whiteC() 
	{
		graph.color = Color.white;
	}
}
