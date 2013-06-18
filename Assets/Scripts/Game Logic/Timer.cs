using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class Timer : MonoBehaviour
{
	public float timeElapsed;
	
	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		//add up time
		timeElapsed += Time.deltaTime;
	}
	
	void OnGUI()
	{
		//display time
		GUI.Label(new Rect(0, 40, 100, 100), "Time Elapsed  " + timeElapsed.ToString("f2"));
	}
}
