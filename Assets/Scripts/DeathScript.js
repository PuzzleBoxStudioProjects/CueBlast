static var lives : int = 3;

private var dead : int = 1;

function OnTriggerEnter(other : Collider)
{
	if (other.gameObject.tag == "Player")
	{
		lives -= dead;
	}
	
	if (lives <= 0)
	{
		Die();
	}
}

function Die()
{
	Application.LoadLevel("with shoot");
	lives = 3;
	startPoints = 0;
}