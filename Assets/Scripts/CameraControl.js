
function Update ()
{
	if (Input.GetMouseButtonDown(0))
	{
		GetComponent("MouseOrbit").enabled = false;
	}
	else if (Input.GetMouseButtonUp(0))
	{
		GetComponent("MouseOrbit").enabled = true;
	}
}