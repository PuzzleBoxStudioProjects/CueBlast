using UnityEngine;
using System.Collections;

public class Gem : MonoBehaviour 
{
	/*private Vector3 spawnPoint;
	float FadeOutTime= 0.0f; 
	bool  FadeOutBool = false;
	
	Color colorStart; 
    Color colorEnd ; 



	
	void Start()
	{
		 colorStart = renderer.material.color; 
         colorEnd = new Color(colorStart.r, colorStart.g, colorStart.b, 0.0f); 

	}
	
	public void Update()
	{
		transform.Rotate(0.0f,0.0f, 50.0f *Time.deltaTime);
		if(FadeOutBool) 
		{
		  FadeOut();
		 //Destroy (rigidbody);
		  Destroy (gameObject,FadeOutTime);
          //Destroy(this);
		}
	}
	
	
	public void OnTriggerEnter(Collider other)
	{
		if(other!=null && other.gameObject)
		{
			BallScript bs = CommonScript.getSingleton().getPlayerBallScript(  other.gameObject);
			if(bs!=null)
			{
				bs.addGem();
			}
		
		 FadeOutBool = true;
			
		}
	}
	
	public void FadeOut ()
	{
		 for (float t = 0.0f; t < FadeOutTime; t += Time.deltaTime) { 
    renderer.material.color = Color.Lerp (colorStart,colorEnd, t/FadeOutTime); 
	}
}*/
}