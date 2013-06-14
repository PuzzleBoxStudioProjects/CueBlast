using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour 
{
	public Texture2D icon;
	public Texture2D  icon2;
	public Texture2D badBorderTex;
	public Texture2D goodBorderTex;
	public Texture2D mapLockedTex;

	/*
	menu states
	*/
	public int MS_NULL								= -1;
	public int MS_SPLASH							= 0x0;
	public int MS_MAIN								= 0x1;
	public int MS_MAPSELECT					= 0x2;
	public int MS_OPTIONS   						= 0x4;
	public int MS_CREDITS 						= 0x8;
	public int MS_ABOUT		   					= 0x10;

	public  int LEVEL_OFFSET	=2;
	public  int CURRENT_NOM_MAPS = 2;
	public  GUISkin mySkin;
	
	private  int m_level = 0;
	private float m_musicVolume = 0;

	public int menuIndex;
	public float offsetX = 0.01f;
	public float offsetY = 0.05f;
	public float  m_difficulty = 0.66f;
	private string scoresResults;
	private bool askServer = true;

	Rect screenRect(float tx,
							float ty,
							float tw,
							float th) 
	{
		float x1 = tx * Screen.width;
		float y1 = ty * Screen.height;
		
		float sw = tw * Screen.width;
		float sh = th * Screen.height;
		
		
		return new Rect(x1,y1,sw,sh);
	}

	void Start()
	{
	
	}
	
	void OnGUI () 
	{
		if(menuIndex!=MS_NULL)
		{
			if(icon!=null)
			{
				if(menuIndex!=MS_MAIN)
				{
					GUI.DrawTexture  (new  Rect (0,0, Screen.width, Screen.height), icon2);
				}else{
					GUI.DrawTexture  (new Rect (0,0, Screen.width, Screen.height), icon);
				}
				
			}
			if(menuIndex==MS_MAIN)
			{
				drawMenu();
			}else if(menuIndex==MS_MAPSELECT)
			{
				drawMapSelect();
			}else if(menuIndex==MS_OPTIONS)
			{
				drawOptions();
			}else if(menuIndex==MS_CREDITS)
			{
				drawCredits();
			}else if(menuIndex == MS_ABOUT)
			{
				drawAbout();
			}
		}
	}

	void setVolume()
	{
		//for(var i=0; i<
	}
	void drawMapSelect()
	{
		GameObject obj =  GameObject.Find("HSController");
		if(obj!=null)
		   {
		     //Transform pos = (Transform)obj.GetComponent("Transform"); 
		     obj.transform.position = new Vector3(0, 0, 0);
		   }
				
				
		//addGUI("Box",0,0,1,1,"Map Select");
		//GUI.Box (screenRect (0,0,1,1), "Map Select");
		int n = 0;
		GUI.skin = mySkin;
		int currentMap =m_level;
			

		int gx = currentMap % 5;
		int gy = currentMap / 5;

		float aw = .28f+ .10f*gx;
		float ah =  0.28f+.2f*gy;		
		
		float border = 0.0125f;	
		
		if(gx!=-1 && gy!=-1)
		{
				GUI.DrawTexture(screenRect (aw-border*.1f,
													ah-border*1.0f,
													.1f+border,
													.075f+border),
													goodBorderTex);
		}
		for(int j=0; j<2; j++)
		{
			for(int i=0; i<5; i++)
			{
				if(GUI.Button (screenRect (.28f+ 0.10f*i,offsetY  + 0.23f+.2f*j,.1f,.075f), "Level: " + n))
				{
					m_level = n;
				}
				n++;
			}
		}

		GUI.skin = null;

		if( GUI.Button (screenRect (offsetX-.1f,offsetY+.7f,.2f,.05f), "Back"))
		{
			menuIndex=MS_MAIN;
		}
		if(GUI.Button (screenRect (offsetX+.2f,offsetY+.7f,.2f,.05f), "Start"))
		{
			loadLevel(false);
		}
	}


	void drawOptions()
	{
		GameObject obj =  GameObject.Find("HSController");
		if(obj!=null)
		   {
		     //Transform pos = (Transform)obj.GetComponent("Transform"); 
		     obj.transform.position = new Vector3(0, 0, 0);
		   }

		GUI.Box (screenRect (offsetX,offsetY,.3f,.5f), "Options");
		GUI.Label  (screenRect (offsetX+.05f,offsetY+.1f,.2f,.05f), "Audio Volume: " +  m_musicVolume  +"%!");
		m_musicVolume = GUI.HorizontalSlider (screenRect (offsetX+.05f,offsetY+.15f,.2f,.05f),m_musicVolume,0.0f,100.0f);





		m_difficulty = GUI.HorizontalSlider (screenRect (offsetX+.05f,offsetY+.25f,.2f,.05f),m_difficulty,0.0f,1.0f);
		string difficultyStr = "Hard";	
		if(m_difficulty <= .33f)
		{
			difficultyStr = "Easy";
		}
		else if(m_difficulty > .33f && m_difficulty<=.66f)
		{
			difficultyStr = "Normal";
		}

		GUI.Label  (screenRect (offsetX+.05f,offsetY+.2f,.2f,.05f), "Difficulty: "  + difficultyStr  );
		
		if(GUI.Button (screenRect (offsetX+.05f,offsetY+.3f,.2f,.05f), "Clear Game Data"))
		{
			PlayerPrefs.SetInt("PLAYER_INDEX", 1);
			m_level=0;
		}
		
		if( GUI.Button (screenRect (offsetX+.05f,offsetY+.4f,.2f,.05f) ,"Back to Main Menu"))
		{
			menuIndex=MS_MAIN;
		}


		
		
		//GUI.Label  (Rect (210,70,140,180), "Sound Volume: 50%");
		//GUI.HorizontalSlider (Rect(210,90,120,20),50.0,0.0,100.0);
		
	}

	void drawMenu()
	{
		GameObject ob =  GameObject.Find("HSController");
		if(ob!=null)
		   {
		     ob.transform.position = new Vector3(0.4f, 0.39f, 0);
		   }
		   
		
		//GUI.Box (screenRect (offsetX,offsetY+.2f,.3f,.3f), "Main Menu");
		if(GUI.Button (screenRect (offsetX+.05f,offsetY+.25f,.2f,.05f), "Start"))
		{
			menuIndex = MS_MAPSELECT;
		}
		if( GUI.Button (screenRect (offsetX+.05f,offsetY+.31f,.2f,.05f) ,"About"))
		{
			menuIndex = MS_ABOUT;
		}

		if(GUI.Button (screenRect (offsetX+.05f,offsetY+.37f,.2f,.05f), "Options"))
		{
			menuIndex=MS_OPTIONS;
		}
		
		if(GUI.Button (screenRect (offsetX+.05f,offsetY+.43f,.2f,.05f), "Credits"))
		{
			menuIndex=MS_CREDITS;
		}
		
		GUI.Box (screenRect (offsetX ,offsetY + .5f,.3f,.42f), "Scores: ");
		
		//float[] myScores = PlayerPrefsX.GetFloatArray("Scores");
		//string[] myNames = PlayerPrefsX.GetStringArray("Names");
		
//		float[] myScores = PlayerPrefsX2.GetFloatArrayPrefs("Scores",10);
	//	string[] myNames = PlayerPrefsX2.GetStringArrayPrefs("Names",10);
		
		
				
		//GUI.Label  (screenRect (offsetX+.05f,offsetY+.55f ,.2f,.05f),s);
		
//		for (int i = 0; i < myNames.Length; i++)

		{
        //GUI.Label  (screenRect (offsetX+.05f,offsetY+.55f + (i*.02f),.2f,.05f), (i+1) + ". " + myNames[i]);
        }
		
	
		
		/*for (int i = 0; i < myScores.Length; i++)
		{
			
		float etime = myScores[i];
		
		if(etime > 0)
			{
		int rawMinutes = (int)etime / 60;

		int minutes = rawMinutes % 60;		
		int seconds = (int)etime % 60;
			
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
		
		string times =  strMinutes + ":" + strSeconds + ":" + strMilliseconds;
        //GUI.Label  (screenRect (offsetX+.15f,offsetY+.55f + (i*.02f),.4f,.05f), times);
	     }
        }
		
		if(askServer)
		{
		StartCoroutine(PostScore.getScores());	
		askServer = false;
		}
		
		scoresResults = PostScore.getScoreResults();
      	   
		
		GameObject obj =  GameObject.Find("HSController");
		if(obj!=null)
		   {
		  GUIText guitext = (GUIText)obj.GetComponent("GUIText"); 
          guitext.text = scoresResults; 
		   }
		  */
	   
		
	}
	
	void drawAbout()
	{
		GameObject obj =  GameObject.Find("HSController");
		if(obj!=null)
		   {
		     //Transform pos = (Transform)obj.GetComponent("Transform"); 
		     obj.transform.position = new Vector3(0, 0, 0);
		   }
		   
		GUI.Box (screenRect (offsetX,offsetY,.3f,.5f), "About");

		if( GUI.Button (screenRect (offsetX+.05f,offsetY+.1f,.2f,.05f) ,"How to Play"))
		{
			//menuIndex=MS_MAIN;
		}
		if( GUI.Button (screenRect (offsetX+.05f,offsetY+.1f,.2f,.05f) ,"Story"))
		{
			//menuIndex=MS_MAIN;
		}


		
		if( GUI.Button (screenRect (offsetX+.05f,offsetY+.4f,.2f,.05f) ,"Back to Main Menu"))
		{
			menuIndex=MS_MAIN;
		}

	}


	void drawCredits()
	{
		GameObject obj =  GameObject.Find("HSController");
		if(obj!=null)
		   {
		     //Transform pos = (Transform)obj.GetComponent("Transform"); 
		     obj.transform.position = new Vector3(0, 0, 0);
		   }
		   
		GUI.Box (screenRect (offsetX,offsetY,.3f,.5f), "Credits");
		GUI.Label  (screenRect (offsetX+.05f,offsetY+.1f,.2f,.05f), "Emmanuel Flores" );
		if( GUI.Button (screenRect (offsetX+.05f,offsetY+.4f,.2f,.05f) ,"Back to Main Menu"))
		{
			menuIndex=MS_MAIN;
		}

	}

	void loadLevel(bool add)
	{
		    askServer = true;
			if(m_level!=-1)
			{
				int currentMap = m_level;
				int level  = currentMap + LEVEL_OFFSET;
				if(add)
				{
					Application.LoadLevelAdditive ( level );
				 }else{
					Application.LoadLevel( level );
				 }
			}
	}
}
