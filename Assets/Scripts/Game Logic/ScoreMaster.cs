using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class ScoreMaster : MonoBehaviour
{
    public static ScoreMaster instance;

    public Vector2 scorePos = Vector2.zero,
                    scoreTextPos = Vector2.zero;

    public GUISkin skin;

	public int curPoints = 0;

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        
    }

    public void AdjustPoints(int adj)
    {
        //adjust score multiplied by the combo counter
        curPoints += adj * GameMaster.instance.comboCounter;
    }

    void OnGUI()
    {
		//display score
        GUI.Label(new Rect(scorePos.x, scorePos.y, 200, 200), "Score  " + curPoints.ToString());
    }
}
