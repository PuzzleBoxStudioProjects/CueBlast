using UnityEngine;
using System.Collections;

public class CameraPhysics : MonoBehaviour
{
	public static CameraPhysics instance;
	
	public Transform target;
	
	public float dist = 5.0f;
	public float minDist = 3.0f;
	public float maxDist = 20.0f;

	public float occlusionSmooth = 0.05f;
	public float distanceSmooth = 0.05f;
	public float smoothDist = 0.05f;
	public float smoothX = 0.05f;
	public float smoothY = 0.1f;
	public float occlusionDistStep = 0.5f;
	
	public float minYLimit = -40.0f;
	public float maxYLimit = 80.0f;
	
	public float mouseYSensitivity = 5.0f;
	public float mouseXSensitivity = 5.0f;
	public float mouseWheelSensitivity = 5.0f;
	
	public int maxOcclusionCheck = 10;
	
	private float mouseY = 0.0f;
	private float mouseX = 0.0f;
	
	private float startDist = 0.0f;
	private float desiredDist = 0.0f;
	private float velocityDist = 0.0f;
	private float preOccludeDist = 0.0f;
	private float velocityX = 0.0f;
	private float velocityY = 0.0f;
	private float velocityZ = 0.0f;
	
	private Vector3 desiredPos = Vector3.zero;
	private Vector3 posit = Vector3.zero;
	
	void Awake()
	{
		instance = this;
		
		Screen.lockCursor = true;
	}
	
	// Use this for initialization
	void Start ()
	{
		//limit dist to min and max values
		dist = Mathf.Clamp(dist, minDist, maxDist);
		startDist = dist;
		
		Reset();
	}
	
	void LateUpdate ()
	{
		//check for target
		if (!target)
		{
			return;
		}
		
		HandlePlayerInput();
		
		int count = 0;
		
		do
		{
			CalculateDesiredPos();
			count++;
		}
		while (CheckIfOccluded(count));
		
		UpdatePos();
	}
	
	void HandlePlayerInput()
	{
		float deadZone = 0.1f;
		
		//handle X input
		mouseX += Input.GetAxis("Mouse X") * mouseXSensitivity;
		
		//handle Y input as long as mouse button is not held
		if (!Input.GetMouseButton(0))
		{
			mouseY -= Input.GetAxis("Mouse Y") * mouseYSensitivity;
		}
		
		//limit the Y
		mouseY = CamHelper.ClampAngle(mouseY, minYLimit, maxYLimit);
		
		if (Input.GetAxis("Mouse ScrollWheel") < -deadZone || Input.GetAxis("Mouse ScrollWheel") > deadZone)
		{
			desiredDist = Mathf.Clamp(dist - Input.GetAxis("Mouse ScrollWheel") * mouseWheelSensitivity, minDist, maxDist);
			preOccludeDist = desiredDist;
			smoothDist = distanceSmooth;
		}
		
		//reset the Y position when aiming to boost
		if (Input.GetMouseButton(0))
		{
			mouseY = 10;
		}
	}
	
	void CalculateDesiredPos()
	{
		ResetDesiredDist();
		//gradually set dist to a target value.  then set the current velocity that will be modified each time this method is called.
		//then the speed in which to move to the target.
		dist = Mathf.SmoothDamp(dist, desiredDist, ref velocityDist, smoothDist);
		//this desired position is going to be given the value of CalculatePos's returned values.
		desiredPos = CalculatePos(mouseY, mouseX, dist);
	}
	
	Vector3 CalculatePos(float rotX, float rotY, float distance)
	{
		//this is going to find the position, rotation and then return the target's position with those values.
		//it will apply this to desiredPos.  subtracting distance will bring the cam back whatever dist is.
		Vector3 dir = new Vector3(0, 0, -distance);
		Quaternion rot = Quaternion.Euler(rotX, rotY, 0);
		return target.position + rot * dir;
	}
	
	bool CheckIfOccluded(int count)
	{
		var isOccluded = false;
		var nearestDist = CheckCamPoints(target.position, desiredPos);
		
		float refVel = 0.0f;
		
		if (nearestDist != -1)
		{
            if (count < maxOcclusionCheck)
            {
                isOccluded = true;
                dist = Mathf.SmoothDamp(dist, occlusionDistStep, ref refVel, occlusionSmooth);

                if (dist < 0.5f)
                {
                    dist = 0.5f;
                }
            }
            else
            {
                dist = nearestDist - Camera.mainCamera.nearClipPlane;
            }
			
			desiredDist = dist;
		}
		
		return isOccluded;
	}
	
	float CheckCamPoints(Vector3 fromHere, Vector3 toHere)
	{
		var nearDist = -1.0f;
		
		RaycastHit hitInfo;
		
		CamHelper.ClipPlanePoints clipPlanePoints = CamHelper.ClipPlaneAtNear(toHere);
		
		Debug.DrawLine(fromHere, toHere + transform.forward * -camera.nearClipPlane, Color.red);
		Debug.DrawLine(fromHere, clipPlanePoints.upperLeft);
		Debug.DrawLine(fromHere, clipPlanePoints.lowerLeft);
		Debug.DrawLine(fromHere, clipPlanePoints.upperRight);
		Debug.DrawLine(fromHere, clipPlanePoints.lowerRight);
		
		Debug.DrawLine(clipPlanePoints.upperLeft, clipPlanePoints.upperRight);
		Debug.DrawLine(clipPlanePoints.upperRight, clipPlanePoints.lowerRight);
		Debug.DrawLine(clipPlanePoints.lowerRight, clipPlanePoints.lowerLeft);
		Debug.DrawLine(clipPlanePoints.lowerLeft, clipPlanePoints.upperLeft);
		
		//set out the linecast that has a starting and an ending point.  also make sure it ignores the player
        if (Physics.Linecast(fromHere, clipPlanePoints.upperLeft, out hitInfo) && hitInfo.collider.tag != "Player")
        {
            nearDist = hitInfo.distance;
        }

        if (Physics.Linecast(fromHere, clipPlanePoints.lowerLeft, out hitInfo) && hitInfo.collider.tag != "Player")
        {
            if (hitInfo.distance < nearDist || nearDist == -1)
            {
                nearDist = hitInfo.distance;
            }
        }

        if (Physics.Linecast(fromHere, clipPlanePoints.upperRight, out hitInfo) && hitInfo.collider.tag != "Player")
        {
            if (hitInfo.distance < nearDist || nearDist == -1)
            {
                nearDist = hitInfo.distance;
            }
        }

        if (Physics.Linecast(fromHere, clipPlanePoints.lowerRight, out hitInfo) && hitInfo.collider.tag != "Player")
        {
            if (hitInfo.distance < nearDist || nearDist == -1)
            {
                nearDist = hitInfo.distance;
            }
        }

        if (Physics.Linecast(fromHere, toHere + transform.forward * -camera.nearClipPlane, out hitInfo) && hitInfo.collider.tag != "Player")
        {
            if (hitInfo.distance < nearDist || nearDist == -1)
            {
                nearDist = hitInfo.distance;
            }
        }
		
		return nearDist;
	}
	
	void ResetDesiredDist()
	{
		if (desiredDist < preOccludeDist)
		{
			var pos = CalculatePos(mouseY, mouseX, preOccludeDist);
			var nearDist = CheckCamPoints(target.position, pos);

            if (nearDist == -1 || nearDist > preOccludeDist)
            {
                desiredDist = preOccludeDist;
            }
		}
	}
	
	void UpdatePos()
	{
		//after the value has been applied we want to smoothdamp the X, Y and Z individually.
		//we do this to create the new Vector3 for posit.  we split up the desiredPos's axis values
		//because we want to first find them then combine them in posit.
		var positX = Mathf.SmoothDamp(posit.x, desiredPos.x, ref velocityX, smoothX);
		var positY = Mathf.SmoothDamp(posit.y, desiredPos.y, ref velocityY, smoothY);
		var positZ = Mathf.SmoothDamp(posit.z, desiredPos.z, ref velocityZ, smoothX);
		
		posit = new Vector3 (positX, positY, positZ);
		//then after all that make the position of the camera be equal to posit.
		//this will be updating all the time so there will constantly be new values being added to posit.
		transform.position = posit;
		//and look at the target.
		transform.LookAt(target);
	}
	
	//reset these values to a default.
	public void Reset()
	{
		mouseX = 0;
		mouseY = 10;
		dist = startDist;
		desiredDist = dist;
		preOccludeDist = dist;
	}
}
