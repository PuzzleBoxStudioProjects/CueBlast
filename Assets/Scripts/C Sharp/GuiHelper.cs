using UnityEngine;
using System.Collections;

public class GUIHelper   : MonoBehaviour {
	/*
	Draws a healthbar.
	
	@param Rect r0
		excepts in the range 0..1
	@param horizontalScroll
		is the scrollbar horizontal
	@param t0
		the first texture.
	@param t1
		the second texture
	*/
	public static void drawHealthBar(Rect r0,
												bool horizontalScroll,
												float val,
												Texture2D t0,
												Texture2D t1)
	{
		float x1 = r0.x;
		float y1 = r0.y;
		float tw = r0.width;
		float ty = r0.height;
		
		if(horizontalScroll==false)
		{
			if(val>1f)
			{
				val=1.0f;
			}
			val = 1f - val;
			
			
			if(val<0)
			{
				val=0;
			}
		}
		float ex = tw * val;
		float ey = ty;
		float len = ex;
		if(horizontalScroll==false)
		{
			ex = tw;
			ey = ty * val;
			len = ey;
		}
		
		float len1 = (horizontalScroll ? tw : ty) * val;
		//Debug.Log("healthBar1b");
		if(t0!=null && t1 !=null)
		{
			//Debug.Log("healthBar2" + x1 + "y1 " + "tw " + tw + "ty " + ty);
			GUI.DrawTexture( GUIHelper.screenRect (x1,y1,-tw,-ty),horizontalScroll ? t0 : t1);
			if(len > 0.0f)
			{
				GUI.DrawTexture(GUIHelper.screenRect (x1,y1,-ex,-ey),horizontalScroll ? t1 : t0);
			}
		}
	}
	
	
	public static void drawLabel(string str,
											float tx,
										    float ty,
											float tw,
											float th)
	{
		GUI.Label(GUIHelper.screenRect(tx,ty,tw,th),str);
	}
	public static Rect screenRect(float tx,
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
}
