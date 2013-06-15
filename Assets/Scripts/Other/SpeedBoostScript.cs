using UnityEngine;
using System.Collections;

public class SpeedBoostScript : MonoBehaviour 
{
	public float speed  = 20;
	
	private GameObject player;
	
	void Awake()
	{
		player = GameObject.FindWithTag("Player");
	}
	
	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
		{
			CueBallPlayer cs;
			cs = player.GetComponent<CueBallPlayer>();
//			CueBallPlayer cs = CommonScript.getSingleton().getPlayerBallScript(  other.gameObject);
			cs.SetSpeedBoost(speed, transform.forward);
		}
	}
}
