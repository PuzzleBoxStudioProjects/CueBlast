using UnityEngine;
using System.Collections;

public class BallScript1 : MonoBehaviour {
	private Vector3 startLocation;
	private Vector3 spawnPoint;
	
	private int gems = 0;
		
	public GameObject effectOnCheckpoint;
	public GameObject effectOnGemCollect;
  	
	public AudioSource soundOnVictory;
	public AudioSource soundOnDeath;
	public AudioSource soundOnSpeedBoost;
	public AudioSource soundOnCheckpoint;
	public AudioSource soundOnCoinCollect;
	public bool victory = false;
	public int lives = 3;
	
	private int initalGemCount;
	
	private LavaScript1 lScript;
	
	//the trail renderer object
	public GameObject trailRenderer;
	//the trails time to live.
	public float trailTTL = 2.0f;
	
	//the trail
	private GameObject m_trail;
	//the trailsCurrent Time to live.
	private float m_currentTrailTTL;
	
	//the field of view start
	private float fovStart = 65.0f;
	private float fovEnd   = 125.0f;
	
	private float m_victoryTime;
	public float victoryTime = .0f;
	void Start () 
	{
		startLocation = transform.position;
		spawnPoint = startLocation;
		initalGemCount = getNomGems();
		
		GameObject Obj  = GameObject.FindWithTag("Floor");
		if(Obj)
		{
			lScript = (LavaScript1)Obj.GetComponent( typeof(LavaScript1));
		}
	}
	
	public void setVictory()
	{
		if(initalGemCount - gems == 0)
		{
		if(victory==false)
		{
			GameObject music = GameObject.FindWithTag("Music");
			if(music)
			{
				AudioSource asMusic = (AudioSource)  music.GetComponent( typeof(AudioSource) );
				asMusic.Stop();
			}
			
			victory = true;
			if(soundOnVictory!=null)
			{
				soundOnVictory.Play();
			}
			//create  an effect when spawning.
			if(effectOnCheckpoint!=null)
			{
				Instantiate(effectOnCheckpoint, transform.position,Quaternion.identity );
			}		
			m_victoryTime = victoryTime;
		}		
	}
	}
	public void setSpawnPoint(Vector3 spawnPos)
	{
		if(spawnPos!=spawnPoint)
		{
			spawnPoint =  spawnPos;
			
			if(soundOnCheckpoint!=null)
			{
				soundOnCheckpoint.Play();
			}
			
			
			//create  an effect when spawning.
			if(effectOnCheckpoint!=null)
			{
				Instantiate(effectOnCheckpoint, spawnPoint,Quaternion.identity );
			}
		}
	}
	
	
	public void respawn()
	{

		
		if(soundOnDeath!=null)
		{
			soundOnDeath.Play();
		}
		destroryTrail();
		
		
		transform.position = spawnPoint;
		rigidbody.velocity = new Vector3(0,0,0);
	}
	
	
	
	public void FixedUpdate()
	{
		checkLives();
		m_currentTrailTTL -= Time.deltaTime;
		//destroy the trail
		float dt = Time.deltaTime;
		if(victory)
		{
			
			m_victoryTime-=dt;
			//if(m_victoryTime<0.0f)
			//{
				
			
				GameObject obj =  GameObject.Find("HUD");
		        if(obj!=null)
		       {
		    //	HUD hu = (HUD)obj.GetComponent( typeof(HUD));
		    	//if(hu && !hu.paused)
		    	{
			//	hu.victory = true;
		    	}
				/*
				float[] Scores = PlayerPrefsX.GetFloatArray("Scores");
	
				
				float[] myScores = new float[10];
				
                   for (int i = 0; i < myScores.Length; i++)
                                            myScores[i] = i+1;

				if (!PlayerPrefsX.SetFloatArray("Scores", myScores))
					           print("Can't save scores");
				
				
				string[] names = new string[10];

				for (int i = 0; i < names.Length; i++)
                     names[i] = (i+1) + "";
				
                
				if (!PlayerPrefsX.SetStringArray("Names", names))
                print("Can't save names");
				
				Screen.showCursor = true;
				Application.LoadLevel(0);
				*/
			}
		//}
	}
		
		
		if(m_currentTrailTTL < 0.0f)
		{
			destroryTrail();
		}else{
			float a = m_currentTrailTTL / trailTTL;
			float b = fovEnd - fovStart;
			
			Camera cam = CommonScript.getSingleton().getMainCamera();
			if(cam)
			{
				cam.fieldOfView = fovStart + (a * b);
			}
			
		}
		
		//move the trail
		if(m_trail)
		{
			m_trail.transform.position = transform.position;
		}
	}
	
	public  Vector3 getPosition()
	{
		return transform.position;
	}
	
	public void setSpeedBoost(float Speed, Vector3 Direction)
	{
		if(soundOnSpeedBoost)
		{
			soundOnSpeedBoost.Play();
		}
		if(trailRenderer)
		{
			destroryTrail();
			Camera cam = CommonScript.getSingleton().getMainCamera();
			if(cam)
			{
				cam.fieldOfView = fovEnd;
			}
			
			
			m_trail =  (GameObject)Instantiate(trailRenderer,transform.position,Quaternion.identity);
			m_currentTrailTTL = trailTTL;
		}
		rigidbody.velocity = new Vector3(0,0,0);
		rigidbody.AddForce (Direction * Speed);
	}
	
		public void addForce(float Speed, Vector3 Direction)
	{
		rigidbody.AddForce (Direction * Speed);
	}
	
	
	void destroryTrail()
	{
		Camera cam = CommonScript.getSingleton().getMainCamera();
		if(cam)
		{
			cam.fieldOfView = fovStart;
		}

		if(m_trail)
		{
			Destroy(m_trail);
		}
	}
	
	public void addGem()
	{
		if(soundOnCoinCollect)
		{
			soundOnCoinCollect.Play();
		}
		if(effectOnGemCollect)
		{
			Instantiate(effectOnGemCollect,transform.position,Quaternion.identity);
		}
		
		
		gems += 1;
	}
	
	int getNomGems()
	{
		int nomGems = 0;
		GameObject gem = GameObject.FindWithTag("Gems");
		if(gem)
		{
			Transform[] transfroms = gem.GetComponentsInChildren<Transform>();
			nomGems = transfroms.Length - 1;
		}
		return nomGems;
	}
	
	public void subLives()
	{
		lives -= 1;
				
	}
	
	public int getCurretLives()
	{
		return lives;
	}
	
	private void checkLives()
	{
		if (lives < 0)
		{
		lives = 3;
		Screen.showCursor = true;
		Application.LoadLevel(0);
		}
	}
	

	
	
}
