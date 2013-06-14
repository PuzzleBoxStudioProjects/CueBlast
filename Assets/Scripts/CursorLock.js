static var show : boolean = false;
static var locked : boolean = false;

function Update()
{
	if (Input.GetButton("Fire1") || locked)
	{
		Screen.lockCursor = false;
	}
	else
	{
		Screen.lockCursor = true;
	}
	
	if (!show)
	{
		Screen.showCursor = false;
	}
	
	if (show)
	{
		Screen.showCursor = true;
	}
}