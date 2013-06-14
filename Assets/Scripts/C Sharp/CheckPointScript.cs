using UnityEngine;
using System.Collections;

public class CheckPointScript : MonoBehaviour 
{
	private Vector3 spawnPoint;
	private LavaScript lScript;
	//public GameObject particleEffectOnEnter;
	
	void Start()
	{
		spawnPoint = new Vector3( transform.position.x,transform.position.y+1.0f,transform.position.z);
		
		GameObject Obj  = GameObject.FindWithTag("Lava");
		if(Obj)
		{
			lScript = (LavaScript)Obj.GetComponent( typeof(LavaScript));
		}
	}
	
	
	/*public void OnTriggerEnter(Collider other)
	{
		if(other!=null && other.gameObject)
		{
			BallScript bs = CommonScript.getSingleton().getPlayerBallScript(  other.gameObject);
			if(bs!=null)
			{
				bs.setSpawnPoint( spawnPoint );
			    lScript.setSpawnPoint( spawnPoint );
			}

		}
	}*/
}