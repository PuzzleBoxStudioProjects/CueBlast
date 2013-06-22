using UnityEngine;
using System.Collections;

public class CamHelper
{

public struct ClipPlanePoints
	{
		public Vector3 upperLeft;
		public Vector3 upperRight;
		public Vector3 lowerLeft;
		public Vector3 lowerRight;
	}
	
	public static float ClampAngle(float angle, float min, float max)
	{
		do
		{
            if (angle < -360)
            {
                angle += 360;
            }
            if (angle > 360)
            {
                angle -= 360;
            }
		}
		while (angle < -360 || angle > 360);
		
		return Mathf.Clamp(angle, min, max);
	}
	
	public static ClipPlanePoints ClipPlaneAtNear(Vector3 pos)
	{
		var clipPlanePoints = new ClipPlanePoints();

        if (Camera.mainCamera == null)
        {
            return clipPlanePoints;
        }
		
		//store the main camera as trans as a reference
		var trans = Camera.mainCamera.transform;
		//divide the field of view to convert to a right triangle.
		//then convert because tangant wants radians not degrees
		//and FOV returns degrees.
		var halfFOV = (Camera.mainCamera.fieldOfView / 2) * Mathf.Deg2Rad;
		//grab the aspect of the camera.
		var aspect = Camera.mainCamera.aspect;
		//find the nearClipPlane of the camera.
		//this is the distance between the camera and the near clip plane.
		var distance = Camera.mainCamera.nearClipPlane;
		//to get the height of the near clip plane we multiply the distance by
		//the tangant of the calculated halfFOV.  this will output the aspect ratio.
		var height = distance * Mathf.Tan(halfFOV);
		//then find the width.
		var width = height * aspect;
		
		//place the points.
		clipPlanePoints.lowerRight = pos + trans.right * width;
		clipPlanePoints.lowerRight -= trans.up * height;
		clipPlanePoints.lowerRight += trans.forward * distance;
		
		clipPlanePoints.lowerLeft = pos - trans.right * width;
		clipPlanePoints.lowerLeft -= trans.up * height;
		clipPlanePoints.lowerLeft += trans.forward * distance;
		
		clipPlanePoints.upperRight = pos + trans.right * width;
		clipPlanePoints.upperRight += trans.up * height;
		clipPlanePoints.upperRight += trans.forward * distance;
		
		clipPlanePoints.upperLeft = pos - trans.right * width;
		clipPlanePoints.upperLeft += trans.up * height;
		clipPlanePoints.upperLeft += trans.forward * distance;
		
		//then return those points
		return clipPlanePoints;
	}
}
