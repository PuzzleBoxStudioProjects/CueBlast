using UnityEngine;
using System.Collections;

public class CommonScript {
	static CommonScript m_instance;
	void Start()
	{
		m_instance = null;
	}
	

	public Rect screenRect(float tx,
								 float ty,
								 float tw,
								 float th) 
	{
		float x1 = tx * Screen.width;
		float y1 = ty * Screen.height;
		
		float sw = tw * Screen.width;
		float	 sh = th * Screen.height;
		
		
		return new Rect(x1,y1,sw,sh);
	}

	public Camera getMainCamera()
	{
		Camera cam = null;
		GameObject obj = GameObject.FindWithTag("MainCamera");
		if(obj!=null)
		{
			cam = (Camera)obj.GetComponent( typeof(Camera));
		}
		return cam;
	}
	public BallScript getPlayerBallScript()
	{
		GameObject obj = GameObject.FindWithTag("Player");
		BallScript bs = null;
		if(obj != null && obj.tag == "Player")
		{
			bs = (BallScript)obj.GetComponent( typeof(BallScript));
		}		
		return bs;
	}
	
	public BallScript getPlayerBallScript(GameObject obj)
	{
		BallScript bs = null;
		if(obj != null && obj.tag == "Player")
		{
			bs = (BallScript)obj.GetComponent( typeof(BallScript));
		}		
		return bs;
	}
	
	public static CommonScript getSingleton()
	{
		if(m_instance==null)
		{
			m_instance = new CommonScript();
		}
		return m_instance;
	}

}
