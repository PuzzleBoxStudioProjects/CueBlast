/*using UnityEngine;
using System.Collections;

public class DeathTriggerScript1 : MonoBehaviour 
{
	private LavaScript lScript;
	
	
	void Start()
	{
		GameObject Obj  = GameObject.FindWithTag("Pocket");
		if(Obj)
		{
			lScript = (LavaScript)Obj.GetComponent( typeof(LavaScript));
		}
	}
	
	public void OnTriggerEnter(Collider other)
	{
		if(other!=null)
		{
			BallScript bs = CommonScript.getSingleton().getPlayerBallScript( other.gameObject);
			if(bs!=null)
			{
				bs.subLives();
				bs.respawn();
				lScript.respawn();
				
			}
		}
	}
}*/