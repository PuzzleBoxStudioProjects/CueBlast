var ball : Transform;
var indicator : Transform;

function Update ()
{
	if (Input.GetMouseButtonDown(0))
	{
		Instantiate(indicator, ball.position, ball.rotation);
	}
	if (Input.GetMouseButtonUp(0))
	{
		Destroy(indicator.gameObject);
	}
}