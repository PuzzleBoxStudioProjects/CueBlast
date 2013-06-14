@script ExecuteInEditMode()

var pointsPos = Vector2.zero;
var livesPos = Vector2.zero;
var guiSkin : GUISkin;
var lifeTextPos = Vector2.zero;
var pointsTextPos = Vector2.zero;
var winButtonPos = Vector2.zero;

static var won : boolean = false;
//static var startPoints : int = 0;
//static var lives : int = 3;

function OnGUI()
{
	var getPoints = Pocket.startPoints;
	var getLives = DeathScript.lives;
	GUI.skin = guiSkin;
	GUI.Label(Rect(pointsPos.x, pointsPos.y, 100, 100), getPoints.ToString());
	GUI.Label(Rect(livesPos.x, livesPos.y, 100, 100), getLives.ToString());
	GUI.Label(Rect(lifeTextPos.x, lifeTextPos.y, 100, 100), "Lives".ToString());
	GUI.Label(Rect(pointsTextPos.x, pointsTextPos.y, 200, 200), "Points".ToString());
	
	if (won)
	{
		if (GUI.Button(Rect(winButtonPos.x, winButtonPos.y, 200, 90), "You won!"))
		{
			Application.LoadLevel("with shoot");
		}
	}
}

function OnLevelWasLoaded()
{
	won = false;
	Pocket.startPoints = 0;
	DeathScript.lives = 3;
	CursorLock.show = false;
	CursorLock.locked = false;
	GameMaster.canCount = false;
	PuttMarbleNEW.canBoost = true;
}