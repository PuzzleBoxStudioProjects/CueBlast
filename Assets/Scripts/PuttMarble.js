var force : float = 1.0;
var cam : Camera;
var ball : Transform;
/*var force0 : Texture2D;
var force1 : Texture2D;
var force2 : Texture2D;
var force3 : Texture2D;
var force4 : Texture2D;
var force5 : Texture2D;
var force6 : Texture2D;
var force7 : Texture2D;
var force8 : Texture2D;
var force9 : Texture2D;
var force10 : Texture2D;
var ballObj : Transform;*/
//var theMaxSpeed : float = 50;
//var minSpeed : float = 50;

private var downPos : Vector2;

function Start(){
	if(!cam) cam = Camera.main;
}

function Update ()
{
	
	if(Input.GetMouseButtonDown(0)) downPos = Input.mousePosition;
		if(Input.GetMouseButtonUp(0))
		{
			
			rigidbody.AddForce(force * Mathf.Abs(downPos.y - Input.mousePosition.y) * Vector3(cam.transform.forward.x, 0, cam.transform.forward.z), ForceMode.Impulse);
			//var speedLimit = Mathf.Clamp(Time.time, minSpeed, theMaxSpeed);
			//rigidbody.velocity.z = speedLimit;
			//rigidbody.velocity.x = speedLimit;
		}
}

function OnGUI()
{
	GUI.Label(Rect(10, 10, 500, 100), "Max Speed: " + ball.rigidbody.velocity.magnitude.ToString());
}