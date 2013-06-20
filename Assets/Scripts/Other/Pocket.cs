using UnityEngine;
using System.Collections;

public class Pocket : MonoBehaviour
{
    public int points = 10;

    public GameObject pocketEmit;

    public AudioClip scoreSound;
	
	private GameObject gameMaster;
	
    void Awake()
    {
       gameMaster = GameObject.Find("__Game Master");
    }

    void OnTriggerEnter(Collider hit)
    {
        if (hit.transform.tag == "OtherBalls")
        {
			GameMaster.instance.ComboSystem();
			
            //goofy fireworks
            Instantiate(pocketEmit, transform.position, transform.rotation);

            //add the points
            GameMaster gm = gameMaster.GetComponent<GameMaster>();
            gm.AdjustPoints(points);

            audio.PlayOneShot(scoreSound);
			
			//reset the amount of hits
			GameMaster.instance.curHitCount = 0;
			
            //take a ball away from the ball count
            GameMaster.instance.ballCountOnLevel--;
        }
    }

    //void ComboSystem()
    //{
    //    if (GameMaster.instance.ballHitCountScore <= 1)
    //    {
    //        comboCounter++;
    //    }
    //}
}
