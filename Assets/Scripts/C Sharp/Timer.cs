using UnityEngine;
using System.Collections;
/*
	A simple timer classs.
*/
public class Timer {
	public float startTime;
	
	
	
	public Timer()
	{
		reset();
	}
	public void reset()
	{
		
		//the current time.
		startTime = Time.time;
	}
		

	public float getElapsedTime()
	{
		float currentTime = Time.time;
		return currentTime - startTime;
	}

	public string getAsString()
	{
		float etime = getElapsedTime();
		
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
		
      return strMinutes + ":" + strSeconds;
	}
	
}
