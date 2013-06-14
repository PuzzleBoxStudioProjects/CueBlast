using UnityEngine;
using System.Collections;

public class marbleControler : MonoBehaviour {

// These variables are for adjusting in the inspector how the object behaves 
public float maxSpeed  = 7;

private float modifier = 1.0f;
	
public float force     = 8;
public float jumpSpeed = 3;
public float jumpTime = 0.005f;


Timer m_timer;
 
// These variables are there for use by the script and don't need to be edited
private float state = 0f;
private bool grounded = false;
private int jumpLimit = 0;
private bool bJump = false;
private  float drag = 2.0f; 

private float hForce;	
private float vForce;

 
	
void Start()
	{
		m_timer = new Timer();
		rigidbody.useConeFriction =true;
	}

// Don't let the Physics Engine rotate this physics object so it doesn't fall over when running
void Awake ()
{ 
}
 
// This part detects whether or not the object is grounded and stores it in a variable
void OnCollisionEnter ()
{
    state ++;
    if(state > 0)
    {
        grounded = true;
    }
}
 
 
void OnCollisionExit ()
{
    state --;
    if(state < 1f)
    {
        grounded = false;
        state = 0f;
    }
}


public virtual bool jump
{
    get 
    {
        return Input.GetButtonDown ("Jump");
    }
}
 
public virtual float horizontal
{
    get
    {
        return Input.GetAxis("Horizontal") * force;
    } 
} 
public virtual float vertical
{
    get
    {
        return Input.GetAxis("Vertical") * force;
    } 
}
// This is called every physics frame
void FixedUpdate ()
{


//Vector3 eulerAngleVelocity =  new Vector3(100, 0, 0);
//Quaternion deltaRotation = Quaternion.Euler(eulerAngleVelocity * Time.deltaTime);
//rigidbody.MoveRotation(rigidbody.rotation * deltaRotation);

	
	if(rigidbody.velocity.magnitude < maxSpeed)
    {
	   Transform mCamera  = Camera.main.transform;
       Vector3 cameraRelativeRight = mCamera .TransformDirection (Vector3.right);
	   Vector3 cameraRelativeforward = mCamera .TransformDirection (Vector3.forward);
    
		cameraRelativeRight.y = 0.0f;
		cameraRelativeforward.y = 0.0f;
	
		vForce = vertical;
		hForce = horizontal;
	if(!grounded)
    {	
	   hForce = hForce / 3;
	   vForce = vForce / 3;
	}	
       //Apply a force relative to the camera's x-axis
	      //rigidbody.AddForce (cameraRelativeRight.normalized * horizontal);
	      //rigidbody.AddForce (cameraRelativeforward.normalized * vertical);
		
		 
		
	      //rigidbody.AddTorque ((cameraRelativeRight.normalized * vertical), ForceMode.Impulse);
	      //rigidbody.AddTorque ((cameraRelativeforward.normalized * -horizontal), ForceMode.Impulse);
		
		  
		  
		  rigidbody.AddForceAtPosition (cameraRelativeRight.normalized * hForce, transform.position + new Vector3 (0,.1f,0) , ForceMode.Impulse);
	      rigidbody.AddForceAtPosition (cameraRelativeforward.normalized * vForce, transform.position + new Vector3 (0,.1f,0), ForceMode.Impulse);
		
		
		

	} 
	
	trailRender();

	
 
	if(jump  && grounded)
    {
		bJump = true;
		jumpLimit = 0;
    }
	
	if (Input.GetButtonUp ("Jump"))
		bJump = false;
		
	
	float ElapsedTime =	m_timer.getElapsedTime();
	
	if(bJump)
	{
		
        rigidbody.velocity = rigidbody.velocity + (Vector3.up * jumpSpeed);
	
		if(ElapsedTime > jumpTime) 
		{	
			bJump = false;
			m_timer.reset();
		}

	}
	

    // This part is for jumping. I only let jump force be applied every 10 physics frames so
    // the player can't somehow get a huge velocity due to multiple jumps in a very short time
	
/*
    if(jumpLimit < 10) jumpLimit ++;
 
    if(jump && grounded  && jumpLimit >= 10)
    {
        rigidbody.velocity = rigidbody.velocity + (Vector3.up * jumpSpeed);
        jumpLimit = 0;
    }
*/
   
	
 }
 

 void trailRender()
 {
		TrailRenderer trail =(TrailRenderer) gameObject.GetComponent( typeof (TrailRenderer));
		if(trail!=null)
		{
			trail.enabled = rigidbody.velocity.magnitude > (maxSpeed / 2.0f);
		}
	 
 }


}