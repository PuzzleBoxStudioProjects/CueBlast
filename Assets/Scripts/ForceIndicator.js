var force0 : Texture2D;
var force1 : Texture2D;
var force2 : Texture2D;
var force3 : Texture2D;
var force4 : Texture2D;
var force5 : Texture2D;
var force6 : Texture2D;
var force7 : Texture2D;
var force8 : Texture2D;
var force9 : Texture2D;
var force10 : Texture2D;

private var allForce : boolean;

function OnGUI()
{
	
	if(Input.GetMouseButtonDown(0))
	{
		allForce = GUI.Toggle(Rect(10, 10, 100, 30), allForce, force0);
		allForce = true;
	}
	if(Input.GetMouseButtonUp(0))
	{
		allForce = false;
	}
}