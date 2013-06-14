/*using UnityEngine;
using System.Collections;

public class LevelEndScript : MonoBehaviour 
{
	
	public void OnTriggerEnter(Collider other)
	{
		if(other!=null && other.gameObject)
		{
			BallScript bs = CommonScript.getSingleton().getPlayerBallScript(  other.gameObject);
			if(bs!=null)
			{
				bs.setVictory();
			}
		}
	}
}
 */