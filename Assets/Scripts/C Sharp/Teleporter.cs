using UnityEngine;
using System.Collections;

public class Teleporter : MonoBehaviour {
		public GameObject targetA;
		public void OnTriggerEnter(Collider other)
	{
		if(other!=null && other.gameObject)
		{
			BallScript bs = CommonScript.getSingleton().getPlayerBallScript(  other.gameObject);
			if(bs!=null)
			{
				bs.transform.position = targetA.transform.position;
			}
		}
	}
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
