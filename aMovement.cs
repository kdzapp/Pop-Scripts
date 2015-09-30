using UnityEngine;
using System.Collections;

public class aMovement : MonoBehaviour {

	public int spB;
	public float rotS;

	void FixedUpdate ()
	{
		var rigidB = GetComponent <Rigidbody>();
		Vector3 movB = new Vector3 (1.0f, 0.0f, 0.0f);
		rigidB.velocity = movB * spB;
		var rotation = Quaternion.identity;
		rotS = rotS + Random.Range(1f,4f);
		rotation.eulerAngles = new Vector3 (0,0,rotS);
		rigidB.rotation = rotation;
		
		if(transform.position.x > 5 || transform.position.x < -5)
		{
			Destroy(this.gameObject);
		}
	}
}