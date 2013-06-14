//Force and speed variables.
var jumpForce : float = 10;
var speed : float = 10;
var maxSpeed : float = 20;

private var stop : boolean = true;
private var jumpLimit : int = 1;

function FixedUpdate ()
{
	//Find the main camera.
	var camBack : Transform = Camera.main.transform;
	//Find which way the camera is facing.
	var cameraRelativeBack : Vector3 = camBack.TransformDirection(-Vector3.forward);
	
	//Find the main camera.
	var camFor : Transform = Camera.main.transform;
	//Find which way the camera is facing.
	var cameraRelativeForward : Vector3 = camFor.TransformDirection(Vector3.forward);
	
	//Make sure the Y axis stays at zero so the player doesn't fly up.
	cameraRelativeForward.y = 0;
	cameraRelativeBack.y = 0;
	
	//Make sure the player doesn't exceed the max speed.
	if (rigidbody.velocity.magnitude < maxSpeed)
	{
		if (Input.GetKey("w") || Input.GetKey("up"))
		{
			//Make the player move wherever the camera is facing.
			rigidbody.AddForceAtPosition(cameraRelativeForward.normalized * speed * Time.deltaTime, transform.position, ForceMode.Impulse);
		}
		
		if (Input.GetKey("s") || Input.GetKey("down"))
		{
			//Make the player move backwards wherever the camera is facing.
			rigidbody.AddForceAtPosition(cameraRelativeBack.normalized * speed * Time.deltaTime, transform.position, ForceMode.Impulse);
		}
	}
	
	//If the jump limit is more than zero.
	if (jumpLimit > 0)
	{
		if (Input.GetButtonDown("Jump"))
		{
			//Make the jump limit zero.
			jumpLimit --;
			//Apply the force to jump.
			rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
		}
	}
	
	//Stop the player from moving in an instant.
	//For more control.
	if (stop)
	{
		if (Input.GetKeyDown("left shift") || Input.GetKeyDown("right shift"))
		{
			rigidbody.isKinematic = true;
		}
	}
	
	if (Input.GetKeyUp("left shift") || Input.GetKeyUp("right shift"))
	{
		rigidbody.isKinematic = false;
	}
}

//Reset the jump limit so the player can jump again.
function OnCollisionEnter()
{
	jumpLimit = 1;
}

//Only allow the player to stop while they're on a collision.
//This way they won't stop in mid air.
function OnCollisionExit()
{
	stop = false;
}

function OnCollisionStay()
{
	stop = true;
}