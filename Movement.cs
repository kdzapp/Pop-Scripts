using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	
	public static Vector3 posB;
	public float speed;
	public float moveH;
	public float moveV;
	public static int scoreM;

	void FixedUpdate () {
		
		if(PopBalloon.gameOn == true)
		{
			var rigidbody = GetComponent <Rigidbody>();
		
			posB = transform.position;
			float moveHorizontal = moveH;
			float moveVertical = moveV;
		
			if (Input.touchCount > 0)
			{
				moveV = -1;
				speed = 4;
			}
			else
			{
				moveV = 1;
				speed = 6;
				scoreM++;
			}
				
			Vector3 movement = new Vector3 (moveHorizontal, moveVertical, 0.0f);
			rigidbody.velocity = movement * speed;
		}
	}
}