using UnityEngine;
using System.Collections;

public class Background : MonoBehaviour {

	public float speedB;
	public float totalB;

	void FixedUpdate () 
	{
		if(PopBalloon.gameOn && transform.position.y > -13)
		{
			totalB = -(speedB*Scorer.score) + 13;
			Vector3 bacP = new Vector3(transform.position.x,totalB, transform.position.z);
			transform.position = bacP;
		}
	}
}
