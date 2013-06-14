using UnityEngine;
using System.Collections;

public class PlatformScript : MonoBehaviour {
	public GameObject targetA;
	public GameObject targetB;
	public float speed = 0.1f;
	private float yPosition;
	private Vector3 Force;

	void Start()
	{
		
	}
	void FixedUpdate () 
	{
		float weight = Mathf.Cos(Time.time * speed * 2.0f * Mathf.PI) * 0.5f + 0.5f;
	
		//transform.position = targetA.transform.position * weight + targetB.transform.position * (1.0f-weight);
		//rigidbody.MovePosition(rigidbody.position + speed * Time.deltaTime);
		rigidbody.MovePosition(targetA.transform.position * weight + targetB.transform.position * (1.0f-weight));
		//Force = (targetA.transform.position * weight + targetB.transform.position * (1.0f-weight) - rigidbody.position) ;
		//rigidbody.AddForce (Force);

	}

}

