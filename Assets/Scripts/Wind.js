var windForce : float = 5;
var player : Transform;
var wind : Transform;

function Update ()
{
	var range = Vector3.Distance(wind.position, player.position);
	
	if (range <= 10)
	{
		player.Translate(player.forward * -windForce * Time.deltaTime);
	}
}