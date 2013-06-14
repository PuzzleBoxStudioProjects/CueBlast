using UnityEngine;
using System.Collections;

public class SpeedBoostScript : MonoBehaviour 
{
	public float Speed  = 20;
	
	void Start()
	{
		
	}
	
	
	public void OnTriggerEnter(Collider other)
	{
		if(other!=null && other.gameObject)
		{
			BallScript bs = CommonScript.getSingleton().getPlayerBallScript(  other.gameObject);
			if(bs!=null)
			{
				bs.setSpeedBoost(Speed, transform.TransformDirection (Vector3.forward) );
			}

		}
	}
}
