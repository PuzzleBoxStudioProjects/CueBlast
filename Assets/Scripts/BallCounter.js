var startCount : int = 0;

function OnCollisionEnter (hit : Collision)
{
	if (hit.gameObject.tag == "OtherBalls")
	{
		startCount ++;
	}
}