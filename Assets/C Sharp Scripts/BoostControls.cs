using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BoostControls : MonoBehaviour
{
	public float force = 1.0f,
				speed = 10.0f,
				boostMultiplier = 5.0f,
				dragDist,
				mouseForce;
	
	public int dragDistance = 400,
				meterIndex = 0;
	
	public bool canBoost = true;
	
	public GUITexture forceMeter;
	
	public Texture2D[] meterImages;
	private Vector2 downPos;
	
	void Update ()
	{
		
		Vector3 relativeCam = -(Camera.main.transform.position - transform.position);
		
		if (canBoost)
		{
			forceMeter.enabled = Input.GetMouseButton(0);
			
			if (Input.GetMouseButton(0))
			{
				dragDist = Mathf.Clamp(Mathf.Abs(downPos.y - Input.mousePosition.y), 0.1f, dragDistance);
				
				mouseForce = dragDist/dragDistance;
				
				forceMeter.texture = meterImages[((int)Mathf.Round(mouseForce * (meterImages.Length - 1)))];
			}
			
			if (Input.GetMouseButtonUp(0))
				rigidbody.AddForce(relativeCam * dragDist * boostMultiplier * Time.deltaTime, ForceMode.VelocityChange);
		}
	}
}
