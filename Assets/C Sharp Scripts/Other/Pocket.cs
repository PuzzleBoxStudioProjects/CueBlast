using UnityEngine;
using System.Collections;

public class Pocket : MonoBehaviour
{
    public static int comboCounter = 1;

    public int points = 10;

    public GameObject pocketEmit;

    public AudioClip scoreSound;

    void Update()
    {
        //reset combo
        //if (GameMaster.instance.ballHitCountScore > 1)
        //{
        //    comboCounter = 1;
        //}
    }

    void OnTriggerEnter(Collider hit)
    {
        if (hit.transform.tag == "OtherBalls")
        {
            //goofy fireworks
            Instantiate(pocketEmit, transform.position, transform.rotation);

            //add the points
            //ScoreMaster sm = (ScoreMaster)ScoreMaster.instance.pocketHit.GetComponent("ScoreMaster");
            //sm.AdjustPoints(points);

            audio.PlayOneShot(scoreSound);

            //take a ball away from the ball count
            //GameMaster.instance.ballCountOnLevel--;
            ////reset the ball hit count
            //GameMaster.instance.ballHitCountScore = 0;

            //ComboSystem();
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
