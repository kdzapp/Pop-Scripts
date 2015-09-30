using UnityEngine;
using System.Collections;

public class bMovement : MonoBehaviour {

	public int spB;
	
	void FixedUpdate ()
	{
		var rigidB = GetComponent <Rigidbody>();
		Vector3 movB = new Vector3 (1.0f, 0.0f, 0.0f);
		rigidB.velocity = movB * spB;
		
		if(transform.position.x > 5 || transform.position.x < -5)
		{
			Destroy(this.gameObject);
		}
	}
}