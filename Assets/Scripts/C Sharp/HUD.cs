/*using UnityEngine;
using System.Collections;

public class HUD	 : MonoBehaviour {
	Timer m_timer;
	public bool paused;
	public GUISkin customSkin;
	private int initalGemCount;
	public Texture2D gemTex;
	public Texture2D thermometer;
	public Texture2D hud_thermometer;
	public Texture2D hud_thermometer2;
	
	public bool victory = false;
	string myString = "Name";
	
	private LavaScript lScript;
	private BallScript bScript;
	
	
	void Start()
	{
		paused = false;
		m_timer = new Timer();
		Screen.showCursor = false;
		initalGemCount = getNomGems();
		
		GameObject Obj  = GameObject.FindWithTag("Lava");
		if(Obj)
		{
			lScript = (LavaScript)Obj.GetComponent( typeof(LavaScript));
		}
		
        Obj  = GameObject.FindWithTag("Player");
		if(Obj)
		{
			bScript = (BallScript)Obj.GetComponent( typeof(BallScript));
		}
		
	}

	void Update () 
	{
		
		if(Input.GetKeyDown( KeyCode.Escape))
		{
			togglePause();
		}	
	}
	void OnGUI() 
	{
		if(customSkin!=null)
		{
			GUI.skin = customSkin;
		}
		

		handleGamePaused();
		handleTime();
		handleGameVictory();
		//handleGameMenu();
	}

	
	void handleGameVictory()
	{
		if(victory)
		{
			float etime = m_timer.getElapsedTime();
			if(!paused)
			{
				togglePause();
			}
			
			float[] Scores;// = PlayerPrefsX2.GetFloatArrayPrefs("Scores",10);
			string[] Names;// = PlayerPrefsX2.GetStringArrayPrefs("Names",10);
			//System.Array.Sort(Scores);
			
			victory = false;
			/*
			for (int i = 0; i < Scores.Length; i++)
				{
					if (etime < Scores[i]  || Scores[i] < 1)
				    {
						victory = true;
					}				
				}
				
			
			
			
			myString = GUI.TextField (CommonScript.getSingleton().screenRect (0.4f,0.40f,.3f,.05f), myString, 8);

						
			GUI.Box  (CommonScript.getSingleton().screenRect (0,0,1,1),"" );
			GUI.Box  (CommonScript.getSingleton().screenRect (0.1f,0.35f,.8f,.22f),"Congratulations!!" );
			
			if(GUI.Button  (CommonScript.getSingleton().screenRect (0.12f,0.46f,.18f,.055f),"Restart" ))
			{
				setPause(false);
				victory = false;
				Application.LoadLevel( Application.loadedLevel);
			}
			
			if(victory)
			{
				
				float[] tempScores = new float[10];
				string[] tempNames = new string[10];

			if(GUI.Button  (CommonScript.getSingleton().screenRect (0.35f,0.46f,.18f,.05f),"Save" ))
			{
				//for (int i = 0; i < Scores.Length; i++)
				//{
					//if (etime < Scores[i]  || Scores[i] < 1)
				    //{
					/*
						for (int l = i; l < Scores.Length-1; l++)
				       {
						//Scores[i] = Scores[l+1] ;
						//Names[i] =  Names[l+1];
						tempScores[l] = Scores[l] ;
						tempNames[l] =  Names[l];
				       }
					   
					   for (int l = i; l < Scores.Length-1; l++)
				       {
						//Scores[i] = Scores[l+1] ;
						//Names[i] =  Names[l+1];
						Scores[l+1] = tempScores[l] ;
						Names[l+1] =  tempNames[l];
				       }
					   
					    Scores[i] = m_timer.getElapsedTime();
						//Names[i] = (i+1) + ". " + myString;
					    Names[i] = myString;
						
					   
						if (!PlayerPrefsX2.SetFloatArrayPrefs("Scores", Scores))
					    print("Can't save scores");
				
				        if (!PlayerPrefsX2.SetStringArrayPrefs("Names", Names))
                            print("Can't save names");
					   
					   
						float timeE = m_timer.getElapsedTime();
		
		                if(timeE > 0)
			            {
		                  int rawMinutes = (int)timeE / 60;
                          int minutes = rawMinutes % 60;		
		                  int seconds = (int)timeE % 60;
			
						  int milliseconds = Mathf.FloorToInt(etime * 1000.0f)%1000; 
				
		                  string strMinutes = minutes.ToString();
		                  
						  if(strMinutes.Length<2)
		                 {
			                strMinutes = "0" + strMinutes;
						 }
		                 string strSeconds = seconds.ToString();
						 if(strSeconds.Length<2)
		                 {
			              strSeconds = "0" + strSeconds;
		                  }
		
		                  string strMilliseconds = milliseconds.ToString("00");
		                  if(strMilliseconds.Length==1)
		                 {
			               strMilliseconds = "00" + strMilliseconds;
						 }
		                 else if(strMilliseconds.Length==2)
		                 {
			              strMilliseconds = "0" + strMilliseconds;
		                  }
		                  
//						  string times =  strMinutes + ":" + strSeconds + ":" + strMilliseconds;
//						  StartCoroutine(PostScore.postScore(myString +" ",times));
						
					 // }	                
						//break;
					//}
				}
				        victory = false;
				        setPause(false);
				        Application.LoadLevel(0);
				        Screen.showCursor = true;
			
			}
			   
		  }
			
			
			if(GUI.Button  (CommonScript.getSingleton().screenRect (0.58f,0.46f,.3f,.05f),"Return to Menu" ))
			{
				victory = false;
				setPause(false);
				Application.LoadLevel(0);
				Screen.showCursor = true;
			}
			
			
		}
	}
	
	void clearScores()
	{
		/*
		float[] Scores = PlayerPrefsX2.GetFloatArrayPrefs("Scores",10);
			string[] Names = PlayerPrefsX2.GetStringArrayPrefs("Names",10);
		
		for (int i = 0; i < Scores.Length; i++)
				{
				
					     Scores[i] = 0;	
                         Names[i] = "";
											
				}
			
  				        if (!PlayerPrefsX2.SetFloatArrayPrefs("Scores", Scores))
					    print("Can't save scores");
				
				        if (!PlayerPrefsX2.SetStringArrayPrefs("Names", Names))
                        print("Can't save names");
							
		
	}
	
	
	void handleGamePaused()
	{
		if(paused && !victory)
		{
			GUI.Box  (CommonScript.getSingleton().screenRect (0,0,1,1),"" );
			GUI.Box  (CommonScript.getSingleton().screenRect (0.10f,0.35f,.8f,.25f),"" );
			if(GUI.Button  (CommonScript.getSingleton().screenRect (0.125f,0.45f,.15f,.05f),"Restart" ))
			{
				setPause(false);
				Application.LoadLevel( Application.loadedLevel);
			}
			if(GUI.Button  (CommonScript.getSingleton().screenRect (0.315f,0.45f,.15f,.05f),"Resume" ))
			{
				setPause(false);
			}
			if(GUI.Button  (CommonScript.getSingleton().screenRect (0.50f,0.45f,.38f,.05f),"Return to Menu" ))
			{
				setPause(false);
				Application.LoadLevel(0);
				Screen.showCursor = true;
			}
		}
	}
	
	
	void handleTime()
	{
		if(m_timer==null)
		{
			return;
		}

		string elapsedTimeStr = m_timer.getAsString();


		if(elapsedTimeStr!=null)
		{
			
           GUI.DrawTexture(CommonScript.getSingleton().screenRect (0.62f,.94625f,.12f,.045f),gemTex);
			
		   float lavaT =  getLavaTime();
		   GUIHelper.drawHealthBar( new Rect(.9748f,0.935f,0.01f,.24f),false,lavaT,hud_thermometer2,hud_thermometer);
		
		   GUI.DrawTexture(CommonScript.getSingleton().screenRect (0.945f,.6725f,.05f,.325f),thermometer);
			
			
			GUI.Box   (CommonScript.getSingleton().screenRect (0.3625f,0.00625f,.285f,.055f), "Time: " + elapsedTimeStr  );
			
			if(initalGemCount>0)
			{
				int nomGems = initalGemCount - getNomGems();
				GUI.Box   (CommonScript.getSingleton().screenRect (0.425f,0.94625f,.185f,.055f),
									"Gems: " + nomGems + "/" + initalGemCount );
			}
			
			int clives = bScript.getCurretLives() ;
			GUI.Box   (CommonScript.getSingleton().screenRect (0.725f,0.94625f,.185f,.055f),
									"Lives: " + clives );
			
       }
	   
		
	}

	
	void togglePause()
	{
		paused = paused ? false : true;
		setPause(paused);
	}
	
	
	
	void setPause(bool p)
	{
		paused = p;
		if(paused==false)
		{
			Screen.showCursor = false;
		}else{
			Screen.showCursor = true;
		}
		GameObject obj =  GameObject.FindWithTag("MainCamera");
		if(obj!=null)
		{
			MouseOrbit mo = (MouseOrbit)obj.GetComponent( typeof(MouseOrbit));
			if(mo)
			{
				mo.enabled = paused==false;
			}
		}

		
		Time.timeScale = paused ? 0.0f : 1.0f;
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
	
	/*float getLavaTime()
	{
		float lTime = 0.0f;
		if(lScript)
		{
			lTime = lScript.getTime();
		}
		return lTime;
	}
}*/