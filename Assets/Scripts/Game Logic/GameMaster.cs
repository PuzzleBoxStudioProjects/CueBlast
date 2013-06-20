using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class GameMaster : MonoBehaviour
{
    public static GameMaster instance;
	
	public int comboCounter = 1;
	
	public float timeElapsed;
	
	private GameObject[] ballsOnLevel; //set the ball count to the amount of balls in each level
	
	[HideInInspector]
    public int ballCountOnLevel = 0;

	public Vector2 winButtonPos = Vector2.zero;
	
	public bool hasWon = false,
                hasLost = false;

    public int levelCount = 0,
                parForLevel = 0,
                curHitCount = 0;
	
	public int curPoints = 0;
	
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
		 //reset combo
        if (curHitCount > 1)
        {
            comboCounter = 1;
        }
        if (ballCountOnLevel == 0)
        {
            //win
            hasWon = true;
        }

        if (curHitCount >= parForLevel)
        {
            hasLost = true;
        }
		
		Timer();
	}
	
	void Timer()
	{
		//add up time
		timeElapsed += Time.deltaTime;
	}
	
	public void ComboSystem()
	{
		//only add up the combo if player hit a ball once before sinking into a pocket
		//in otherwords, a hole in one
		if (curHitCount == 1)
		{
			comboCounter++;
		}
	}
	
    public void AdjustPoints(int adj)
    {
        //adjust score multiplied by the combo counter
        curPoints += adj * comboCounter;
    }

    void OnGUI()
    {
		//display combo multiplier
		GUI.Label(new Rect(0, 20, 100, 100), "Combo  " + comboCounter.ToString() + "x");
		
        //temporary buttons.
        if (hasWon)
        {
			//load next level
            if (GUI.Button(new Rect(Screen.width / 2, Screen.height / 2, 100, 30), "Load next level."))
            {
                Application.LoadLevel(Application.loadedLevel + 1);
            }
        }
        if (hasLost)
        {
			//reload level
            if (GUI.Button(new Rect(Screen.width / 2, Screen.height / 2, 100, 30), "Reload level."))
            {
                Application.LoadLevel(Application.loadedLevel);
            }
        }
		
		//display time
		GUI.Label(new Rect(0, 40, 100, 100), "Time Elapsed  " + timeElapsed.ToString("f2"));
		
		//display score
        GUI.Label(new Rect(0, 0, 200, 200), "Score  " + curPoints.ToString());
    }

    //public void Restart()
    //{
    //    ScoreMaster.instance.curPoints = 0;
    //    CueBallPlayer.instance.lives = 3;
    //    hasWon = false;
    //    hasLost = false;
    //}
}
