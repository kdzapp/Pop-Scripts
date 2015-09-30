using UnityEngine;
using System.Collections;

public class PopBalloon : MonoBehaviour
{
	public static bool gameOn = false; //Universal Trigger of whether the game is being played or not
	public bool instC = true;
	
	public static Vector3 OrginB = new Vector3(0f, -4.0f, -0.2f);
	
	void OnTriggerExit(Collider other)
    {
		if(other.tag == "Boundry" & gameOn == true & this.tag != "Bird" & this.tag != "Astroid")
		{
			var Score = GameObject.Find("Score");  //Prevents Runaway Score
			var Scorer = Score.GetComponent<Scorer>();
			Scorer.enabled = false;
			if(instC) //Prevents Double Balloon Pop
			{
				gameOn = false;
				Instantiate(Resources.Load("PoppedBalloon_0") as GameObject, Movement.posB, transform.rotation);
				instC = false;
			}
			StartCoroutine (reload());
		}
	}
	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Bird" & gameOn == true & this.tag != "Bird" & this.tag != "Astroid")
		{
			var Score = GameObject.Find("Score"); //Prevents Runaway Score
			var Scorer = Score.GetComponent<Scorer>();
			Scorer.enabled = false;
			if(instC) //Prevents Double Balloon Pop
			{
				gameOn = false;
				Instantiate(Resources.Load("PoppedBalloon_0") as GameObject, Movement.posB, transform.rotation);
				instC = false;
			}
			StartCoroutine (reload());
		}
		else if(other.tag == "Astroid" & gameOn == true & this.tag != "Astroid" & this.tag != "Bird")
		{
			var Score = GameObject.Find("Score"); //Prevents Runaway Score
			var Scorer = Score.GetComponent<Scorer>();
			Scorer.enabled = false;
			if(instC) //Prevents Double Balloon Pop
			{
				gameOn = false;
				Instantiate(Resources.Load("PoppedBalloon_0") as GameObject, Movement.posB, transform.rotation);
				instC = false;
			}
			StartCoroutine (reload());
		}
	}
	IEnumerator reload ()
	{
		var renderer = GetComponent<Renderer>();
		renderer.enabled = false;
		yield return new WaitForSeconds(0.75f);
		Movement.scoreM = 0;
		GameController.adCount++; //Adds to Ad Count (5 games = 1 ad)
		instC = true; //Prevents Double Balloon Pop
		var gO = GameObject.Find("Player");
		Destroy(gO); //Destroys Balloon
		Application.LoadLevel(1); //Resets Game
		Tap.inst = 1;
		PlayerPrefs.Save(); //Saves Info
	}
}