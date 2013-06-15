using UnityEngine;
using System.Collections;

public class BallCounter : MonoBehaviour
{
	public int startCount = 0;
	
	void OnCollisionEnter(Collision hit)
	{
        if (hit.gameObject.tag == "OtherBalls")
        {
            startCount++;
        }
	}
}
