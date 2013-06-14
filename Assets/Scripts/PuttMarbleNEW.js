var force : float = 1.0;
var cam : Camera;
var forceMeter : GUITexture;
var meterImages : Texture2D[];
var dragDistance : float = 400.0;
var speed : float = 10;
var startPoint : Transform;

private var mouseForce: float = 0.0;
private var downPos : Vector2;
private var lastCheckpoint : Transform;

static var canBoost : boolean = true;

function Start()
{
	if(!cam) cam = Camera.main;
}

function Update ()
{
	if (canBoost)
	{
		//enable the forcemeter when you press the mouse button.
		forceMeter.enabled = Input.GetMouseButton(0);
		//this is the magic that makes the force meter work correctly.
		//If the mouse button is pressed activate downPos which is a Vector2 (declared at top)
		//with the value of where the mouse is positioned
		if(Input.GetMouseButtonDown(0))	downPos = Input.mousePosition;
		//While holding the mouse down.
		if(Input.GetMouseButton(0))
		{
			//Declare this variable as a float with the value of
			//A Mathf.Clamp that will restrict a minimum value and a maximum value
			//Mathf.Clamp requires a value and a minimum and maximum value
			//In this it has a Mathf.Abs that just returns the absolute value of the values.
			//downPos.y minus the mouse position.y, which is only allowing it to drag on the Y axis
			//the other two are just the min and max values
			var dragDist : float = Mathf.Clamp(Mathf.Abs(downPos.y - Input.mousePosition.y), 0.1, dragDistance);
			//Now the mouseForce (which we declared as a float at the top) we will give it a value of dragDist
			//divided by the dragDistance.
			mouseForce = dragDist/dragDistance;
			//What this does is basically draw the force meter.
			//forceMeter as a GUI texture with the value
			//meterImages that are in an array
			//Mathf.Round is rounding to the nearest ineger.  mouseForce multiplied by
			//The meterImages dot length minus 1.  length just sets the number of elements in the array.
			//Minus 1 is using one image at a time.
			forceMeter.texture = meterImages[Mathf.Round(mouseForce * (meterImages.length - 1))];
		}
		
		//Let go and that sucker flies.
		if(Input.GetMouseButtonUp(0)) rigidbody.AddForce(mouseForce * force * Vector3(cam.transform.forward.x, 0, cam.transform.forward.z), ForceMode.VelocityChange);
	}
}

//That's as far as I understand it.  There's probably more to it but that's the jist.