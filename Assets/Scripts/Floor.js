var lostLife : int = 1;

static var lives : int = 3;

function OnTriggerEnter (hit : Collider)
{
	if (hit.gameObject.tag == "Player")
	{
		lives -= lostLife;
	}
}