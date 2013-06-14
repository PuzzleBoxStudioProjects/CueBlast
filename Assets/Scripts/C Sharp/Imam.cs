using UnityEngine;
using System.Collections;

public class Imam : MonoBehaviour {
	public float force = 20f;
	public void OnTriggerStay(Collider other)
	{
		if(other!=null)
		{
			BallScript bs = CommonScript.getSingleton().getPlayerBallScript( other.gameObject);
			if(bs!=null)
			{
				Vector3 pos = bs.getPosition();
				Vector3 res = transform.parent.position - pos;
				bs.addForce(force, res.normalized);
			
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
