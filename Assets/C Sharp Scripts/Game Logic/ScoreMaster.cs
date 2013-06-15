using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class ScoreMaster : MonoBehaviour
{
    public static ScoreMaster instance;

    public GameObject pocketHit;

    public Vector2 scorePos = Vector2.zero,
                    scoreTextPos = Vector2.zero;

    public GUISkin skin;

	public int curPoints = 0;

    void Awake()
    {
        pocketHit = gameObject;

        instance = this;
    }

    void Update()
    {
        AdjustPoints(0);
    }

    public void AdjustPoints(int adj)
    {
        //adjust score multiplied by the combo counter
        curPoints += adj * Pocket.comboCounter;
    }

    void OnGUI()
    {
        GUI.skin = skin;
        GUI.Label(new Rect(scorePos.x, scorePos.y, 200, 200), "Score " + curPoints.ToString());
    }
}
