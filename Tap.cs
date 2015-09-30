using UnityEngine;
using System.Collections;

public class Tap : MonoBehaviour {

	public static int inst;

	void Start ()
	{
		PlayerPrefs.SetInt ("Inst", inst);
	}
	
	void Update ()
	{

		if (PopBalloon.gameOn == true && PlayerPrefs.GetInt ("Inst") != 1)
		{
			Destroy (gameObject);
		}
		else if(PlayerPrefs.GetInt ("Inst") == 1)
		{
			Destroy (gameObject);
		}
		else
		{
			;
		}
	
	}
}
