using UnityEngine;
using System.Collections;

public class CueControls : MonoBehaviour
{
	public float jumpForce = 10.0f;
	public float speed = 10.0f;
	public float maxSpeed = 20.0f;
	
	private bool stop = true;
	private int jumpLimit = 1;
	
	// Update is called once per frame
	void Update ()
	{
		Vector3 relativeCam = -(Camera.main.transform.position - transform.position);

		relativeCam.x = 0;
		
		if (rigidbody.velocity.magnitude < maxSpeed)
		{
			if (Input.GetAxis("Vertical") > 0)
				rigidbody.AddForceAtPosition(relativeCam * speed * Time.deltaTime, transform.position, ForceMode.Impulse);
			
			if (Input.GetAxis("Vertical") < 0)
				rigidbody.AddForceAtPosition(relativeCam * -speed * Time.deltaTime, transform.position, ForceMode.Impulse);
		}
		
		if (jumpLimit > 0)
		{
			if (Input.GetButtonDown("Jump"))
			{
				jumpLimit--;
				rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
			}
		}
		
		if (stop)
		{
			if (Input.GetKeyDown(KeyCode.LeftShift))
				rigidbody.isKinematic = true;
		}
		
		if (Input.GetKeyUp(KeyCode.LeftShift))
			rigidbody.isKinematic = false;
	}
	
	void OnCollisionEnter()
	{
		jumpLimit = 1;
	}
	
	void OnCollisionExit()
	{
		stop = false;
	}
	
	void OnCollisionStay()
	{
		stop = true;
	}
}
