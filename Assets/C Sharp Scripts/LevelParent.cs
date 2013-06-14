using UnityEngine;
using System.Collections;

public class LevelParent : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
	    
	}

    void OnLevelWasLoaded(int level)
    {
        //BroadcastMessage("Restart");

        //if (level == Application.loadedLevel)
        //{
        //    DontDestroyOnLoad(transform.gameObject);
        //}
    }
}
