using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour
{
    public static GameMaster instance;

	public GameObject[] ballsOnLevel; //set the ball count to the amount of balls in each level

    public int ballCountOnLevel = 0;

	public Vector2 winButtonPos = Vector2.zero;
	
	public bool canCount = false,
				hasWon = false,
                hasLost = false;

    public int levelCount = 0,
                parForLevel = 0,
                ballHitCountScore = 0;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        ballsOnLevel = GameObject.FindGameObjectsWithTag("OtherBalls");
        ballCountOnLevel = ballsOnLevel.Length;
    }

	// Update is called once per frame
	void Update ()
	{
        //if (ballCountOnLevel <= 0)
        //{
        //    //win
        //    hasWon = true;
        //}

        //if (ballHitCountScore >= parForLevel)
        //{
        //    hasLost = true;
        //}
	}


    //public void Dead()
    //{
    //    Application.LoadLevel(levelCount);
    //}

    //void OnGUI()
    //{
    //    //temporary buttons.
    //    if (hasWon)
    //    {
    //        if (GUI.Button(new Rect(Screen.width / 2, Screen.height / 2, 100, 30), "Load next level."))
    //        {
    //            Application.LoadLevel(Application.loadedLevel + 1);
    //        }
    //    }
    //    if (hasLost)
    //    {
    //        if (GUI.Button(new Rect(Screen.width / 2, Screen.height / 2, 100, 30), "Reload level."))
    //        {
    //            Application.LoadLevel(Application.loadedLevel);
    //        }
    //    }
    //}

    //public void Restart()
    //{
    //    ScoreMaster.instance.curPoints = 0;
    //    CueBallPlayer.instance.lives = 3;
    //    hasWon = false;
    //    hasLost = false;
    //}
}
