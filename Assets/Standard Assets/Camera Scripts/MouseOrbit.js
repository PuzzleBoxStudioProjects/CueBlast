var target : Transform;
var distance = 10.0;

var xSpeed = 250.0;
var ySpeed = 120.0;

var yMinLimit = -20;
var yMaxLimit = 80;

var zoomRate : float = 3;
var minDistance = 10;
var maxDistance = 50;

private var x = 0.0;
private var y = 0.0;
private var DisableEnable : boolean;

@script AddComponentMenu("Camera-Control/Mouse Orbit")

function Start ()
{
    var angles = transform.eulerAngles;
    x = angles.y;
    y = angles.x;

	// Make the rigid body not change rotation
   	if (rigidbody)
		rigidbody.freezeRotation = true;
}

function LateUpdate ()
{
    if (target)
    {
    	x += Input.GetAxis("Mouse X") * xSpeed * 0.02;
        var rotation = Quaternion.Euler(y, x, 0);
        var position = rotation * Vector3(0.0, 0.0, -distance) + target.position;
        
        transform.rotation = rotation;
        transform.position = position;
    }
    distance -= (Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime) * zoomRate * Mathf.Abs(distance); 
   	distance = Mathf.Clamp(distance, minDistance, maxDistance); 
}

static function ClampAngle (angle : float, min : float, max : float)
{
	if (angle < -360)
		angle += 360;
	if (angle > 360)
		angle -= 360;
	return Mathf.Clamp (angle, min, max);
}

function Awake()
{
	DisableEnable = true;
}

function Update()
{
	if (Input.GetMouseButtonDown(0))
	{
		DisableEnable = false;
	}
	else if (Input.GetMouseButtonUp(0))
	{
		DisableEnable = true;
	}
	if (DisableEnable)
	{
	    y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02;
 		
	 	y = ClampAngle(y, yMinLimit, yMaxLimit);
	}
}