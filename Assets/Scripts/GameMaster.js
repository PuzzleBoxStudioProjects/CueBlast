var ballCount : int;

static var canCount : boolean = false;

function Update()
{
	if (canCount)
	{
		ballCount --;
		canCount = false;
	}
	
	if (ballCount <= 0)
	{
		PointsHUD.won = true;
		CursorLock.show = true;
		CursorLock.locked = true;
		PuttMarbleNEW.canBoost = false;
		//Debug.Log("You win!");
	}
}