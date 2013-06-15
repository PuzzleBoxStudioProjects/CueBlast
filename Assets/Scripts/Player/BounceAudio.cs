using UnityEngine;
using System.Collections;

public class BounceAudio : MonoBehaviour
{
    public AudioClip bounce;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    void OnCollisionEnter(Collision col)
    {
        if (col.transform.tag != "OtherBalls")
        {
            audio.PlayOneShot(bounce);
        }
    }
}
