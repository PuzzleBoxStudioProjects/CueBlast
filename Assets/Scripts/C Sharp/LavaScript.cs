using UnityEngine;
using System.Collections;

public class LavaScript : MonoBehaviour {
	public GameObject targetA;
	public GameObject targetB;
	public AudioSource soundOnMoving;
	public float speed = 0.1f;
	private float yPosition;
	private Vector3 Force;
	private bool MoveLava;
	private bool MoveLava2;
	public float MovingTime;
	
	private float etime;
	public Vector3 spawnPoint;

	
	private Timer m_timer;

	void Start()
	{
		m_timer = new Timer();
		MoveLava = true;
	}
	/*void FixedUpdate () 
	{
		float weight = Mathf.Cos(Time.time * speed * 2.0f * Mathf.PI) * 0.5f + 0.5f;
	
	
		if (MoveLava)
		rigidbody.MovePosition(targetA.transform.position * weight + targetB.transform.position * (1.0f-weight));

		etime = m_timer.getElapsedTime();
		
		if(etime > MovingTime) 
		{
			targetA.transform.position += new Vector3(0, .001f, 0);
            targetB.transform.position += new Vector3(0, .001f, 0);			
			
			if(soundOnMoving)
		{
			 if (!soundOnMoving.isPlaying) 
		  {
			soundOnMoving.Play();
		  }
		  
		 }

		  if (etime > MovingTime+15) 
		  {
		    m_timer.reset();
		  }
		

	}

}

public float getTime()
{
	float rTime = (MovingTime /  etime);
	rTime = rTime / etime;
	return rTime;
}*/

public void setSpawnPoint(Vector3 spawnPos)
	{
		if(spawnPos!=spawnPoint)
		{
			spawnPoint =  spawnPos;
		}
	}
	
	public void respawn()
	{
      //Debug.Log(spawnPoint);
	  //Debug.Log(transform.localPosition);
		
	  Vector3 pos = spawnPoint -transform.position;
	  //Debug.Log(pos);
		
		
	 // targetA.transform.localPosition = pos;
	//  targetB.transform.localPosition = targetA.transform.localPosition - new Vector3(0,4,0);
	  m_timer.reset();
	}
	public Vector3 getPosition()
	{
		return transform.position;
	}

}

