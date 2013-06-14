/*using UnityEngine;
using System.Collections;

public class DeathTriggerScript : MonoBehaviour 
{
	private LavaScript lScript;
	
	
	void Start()
	{
		GameObject Obj  = GameObject.FindWithTag("Floor");
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
}
 */